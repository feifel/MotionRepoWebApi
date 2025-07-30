using MotionRepoServer.Models;

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
        InitializeSampleData();
    }

    private void InitializeSampleData()
    {
        var motions = _motionService.GetMotions(0, 50, null, null).Data.ToList();
        if (!motions.Any())
            return;

        var workouts = new List<Workout>
        {
            new Workout
            {
                Id = Guid.Parse("3313c09e-2f1e-4b19-bab2-aed759966b6f"),
                Name = "Morning Warm-up Routine",
                Description = "A quick 10-minute warm-up routine to start your day with energy and flexibility",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Standing Pose")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 15,
                        Duration = 60,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "notes", "Focus on smooth, controlled movements" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Air Squat")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 10,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "notes", "Keep your back straight and chest up" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("38d8baa2-c288-448c-8a44-98226e477a62"),
                Name = "Core Strength Builder",
                Description = "A focused core workout to build abdominal and lower back strength",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Pushup")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 15,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "notes", "Maintain proper plank position throughout" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Laying On The Floor")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 1,
                        Duration = 60,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "notes", "Use as active recovery between sets" }
                        }
                    }
                }
            }
        };

        _workouts.AddRange(workouts);
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