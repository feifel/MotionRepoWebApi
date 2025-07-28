using MotionRepoServer.Models;

namespace MotionRepoServer.Services;

public class WorkoutService
{
    private readonly List<Workout> _workouts;
    private readonly MotionService _motionService;

    public WorkoutService(MotionService motionService)
    {
        _motionService = motionService;
        _workouts = new List<Workout>();
        
        // Initialize with sample data
        InitializeSampleData();
    }

    private void InitializeSampleData()
    {
        var motions = _motionService.GetMotions(0, 10, null, null).Data.ToList();
        if (motions.Any())
        {
            var sampleWorkout = new Workout
            {
                Name = "Morning Warm-up Routine",
                Description = "A quick 10-minute warm-up routine to start your day",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.First().Id,
                        Speed = 1,
                        Repetitions = 15,
                        Duration = 60,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "notes", "Focus on smooth movements" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(1).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 10,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 5.0 },
                            { "rest_time", 30 }
                        }
                    }
                }
            };
            _workouts.Add(sampleWorkout);
        }
    }

    public PagedResponse<Workout> GetWorkouts(int? offset = null, int? limit = null, string? search = null)
    {
        var query = _workouts.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var searchTerm = search.ToLower();
            query = query.Where(w => 
                w.Name.ToLower().Contains(searchTerm) || 
                w.Description.ToLower().Contains(searchTerm));
        }

        var total = query.Count();
        var offsetValue = offset ?? 0;
        var limitValue = limit ?? 10;

        var data = query
            .Skip(offsetValue)
            .Take(limitValue)
            .ToList();

        return new PagedResponse<Workout>(data, total, offsetValue, limitValue);
    }

    public Workout? GetWorkoutById(Guid id)
    {
        return _workouts.FirstOrDefault(w => w.Id == id);
    }

    public Workout CreateWorkout(CreateWorkoutRequest request)
    {
        var exercises = new List<Exercise>();

        foreach (var exerciseRequest in request.Exercises)
        {
            // Validate that the motion exists
            var motion = _motionService.GetMotionById(exerciseRequest.MotionId);
            if (motion == null)
            {
                throw new ArgumentException($"Motion with ID {exerciseRequest.MotionId} not found");
            }

            var exercise = new Exercise
            {
                MotionId = exerciseRequest.MotionId,
                Speed = exerciseRequest.Speed,
                Repetitions = exerciseRequest.Repetitions,
                Duration = exerciseRequest.Duration,
                ExerciseType = exerciseRequest.ExerciseType,
                CustomFields = exerciseRequest.CustomFields ?? new Dictionary<string, object>(),
                AvatarId = exerciseRequest.AvatarId
            };
            exercises.Add(exercise);
        }

        var workout = new Workout
        {
            Name = request.Name,
            Description = request.Description,
            Exercises = exercises,
            AvatarId = request.AvatarId
        };

        _workouts.Add(workout);
        return workout;
    }

    public Workout? UpdateWorkout(Guid id, UpdateWorkoutRequest request)
    {
        var workout = _workouts.FirstOrDefault(w => w.Id == id);
        if (workout == null)
        {
            return null;
        }

        var exercises = new List<Exercise>();

        foreach (var exerciseRequest in request.Exercises)
        {
            // Validate that the motion exists
            var motion = _motionService.GetMotionById(exerciseRequest.MotionId);
            if (motion == null)
            {
                throw new ArgumentException($"Motion with ID {exerciseRequest.MotionId} not found");
            }

            var exercise = new Exercise
            {
                Id = exerciseRequest.ExerciseId ?? Guid.NewGuid(),
                MotionId = exerciseRequest.MotionId,
                Speed = exerciseRequest.Speed,
                Repetitions = exerciseRequest.Repetitions,
                Duration = exerciseRequest.Duration,
                ExerciseType = exerciseRequest.ExerciseType,
                CustomFields = exerciseRequest.CustomFields ?? new Dictionary<string, object>(),
                AvatarId = exerciseRequest.AvatarId
            };
            exercises.Add(exercise);
        }

        // Update the workout in place
        var index = _workouts.FindIndex(w => w.Id == id);
        _workouts[index] = workout with
        {
            Name = request.Name,
            Description = request.Description,
            Exercises = exercises
        };

        return _workouts[index];
    }

    public bool DeleteWorkout(Guid id)
    {
        var workout = _workouts.FirstOrDefault(w => w.Id == id);
        if (workout == null)
        {
            return false;
        }

        _workouts.Remove(workout);
        return true;
    }
}