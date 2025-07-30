using MotionRepoServer.Models;
using MotionRepoServer.Data;

namespace MotionRepoServer.Services;

public class WorkoutService
{
    private readonly List<Workout> _workouts;
    private readonly MotionService _motionService;
    private readonly GitHubRepositoryService _gitHubService;
    private bool _initialized = false;

    public WorkoutService(MotionService motionService, GitHubRepositoryService gitHubService)
    {
        _motionService = motionService;
        _gitHubService = gitHubService;
        _workouts = new List<Workout>();
        
        // Initialize with sample data as fallback
        _workouts.AddRange(WorkoutSampleData.GetSampleWorkouts());
    }

    public async Task InitializeAsync()
    {
        if (_initialized) return;

        // Initialize motion service first
        await _motionService.InitializeAsync();

        if (_gitHubService.IsConfigured)
        {
            var githubWorkouts = await _gitHubService.LoadWorkoutsAsync();
            if (githubWorkouts.Any())
            {
                _workouts.Clear();
                _workouts.AddRange(githubWorkouts);
            }
        }

        _initialized = true;
    }

    public PagedResponse<Workout> GetWorkouts(int? offset, int? limit, string? search)
    {
        var filteredWorkouts = _workouts.AsEnumerable();

        // Filter by text if provided (search in Name and Description)
        if (!string.IsNullOrWhiteSpace(search))
        {
            var searchWords = search.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(word => word.Trim().ToLowerInvariant())
                                  .Where(word => !string.IsNullOrEmpty(word))
                                  .ToList();

            if (searchWords.Any())
            {
                filteredWorkouts = filteredWorkouts.Where(w =>
                    searchWords.Any(word =>
                        w.Name.Contains(word, StringComparison.OrdinalIgnoreCase) ||
                        w.Description.Contains(word, StringComparison.OrdinalIgnoreCase)
                    )
                );
            }
        }

        var totalCount = filteredWorkouts.Count();
        var offsetValue = offset ?? 0;
        var limitValue = limit ?? 50;

        var pagedWorkouts = filteredWorkouts
            .Skip(offsetValue)
            .Take(limitValue)
            .ToList();

        return new PagedResponse<Workout>(pagedWorkouts, totalCount, offsetValue, limitValue);
    }

    public Workout? GetWorkoutById(Guid id)
    {
        return _workouts.FirstOrDefault(w => w.Id == id);
    }

    public Workout CreateWorkout(CreateWorkoutRequest request)
    {
        // Validate all motion IDs exist
        foreach (var exercise in request.Exercises)
        {
            var motion = _motionService.GetMotionById(exercise.MotionId);
            if (motion == null)
            {
                throw new ArgumentException($"Motion with ID {exercise.MotionId} not found");
            }
        }

        var workout = new Workout
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            AvatarId = request.AvatarId,
            Exercises = request.Exercises.Select(e => new Exercise
            {
                Id = Guid.NewGuid(),
                MotionId = e.MotionId,
                AvatarId = e.AvatarId,
                Speed = e.Speed,
                Repetitions = e.Repetitions,
                Duration = e.Duration,
                ExerciseType = e.ExerciseType,
                CustomFields = e.CustomFields
            }).ToList()
        };

        _workouts.Add(workout);
        return workout;
    }

    public Workout? UpdateWorkout(Guid id, UpdateWorkoutRequest request)
    {
        var existingWorkout = _workouts.FirstOrDefault(w => w.Id == id);
        if (existingWorkout == null)
            return null;

        // Validate all motion IDs exist
        foreach (var exercise in request.Exercises)
        {
            var motion = _motionService.GetMotionById(exercise.MotionId);
            if (motion == null)
            {
                throw new ArgumentException($"Motion with ID {exercise.MotionId} not found");
            }
        }

        var updatedWorkout = new Workout
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            AvatarId = request.AvatarId,
            Exercises = request.Exercises.Select(e => new Exercise
            {
                Id = Guid.NewGuid(),
                MotionId = e.MotionId,
                AvatarId = e.AvatarId,
                Speed = e.Speed,
                Repetitions = e.Repetitions,
                Duration = e.Duration,
                ExerciseType = e.ExerciseType,
                CustomFields = e.CustomFields
            }).ToList()
        };

        var index = _workouts.FindIndex(w => w.Id == id);
        _workouts[index] = updatedWorkout;

        return updatedWorkout;
    }

    public bool DeleteWorkout(Guid id)
    {
        var workout = _workouts.FirstOrDefault(w => w.Id == id);
        if (workout == null)
            return false;

        _workouts.Remove(workout);
        return true;
    }
}