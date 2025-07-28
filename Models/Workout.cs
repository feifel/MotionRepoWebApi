using MotionRepoServer.Models;

namespace MotionRepoServer.Models;

public record Workout
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public Guid? AvatarId { get; init; }
    public List<Exercise> Exercises { get; init; } = new();
}

public record Exercise
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid MotionId { get; init; } = Guid.Empty;
    public Guid? AvatarId { get; init; }
    public int Speed { get; init; } = 1;
    public int Repetitions { get; init; } = 10;
    public int Duration { get; init; } = 30;
    public ExerciseType ExerciseType { get; init; } = ExerciseType.Repetition;
    public Dictionary<string, object> CustomFields { get; init; } = new();
}

public enum ExerciseType
{
    Repetition,
    Duration
}

// Request records for CRUD operations
public record CreateWorkoutRequest(
    string Name,
    string Description,
    List<CreateExerciseRequest> Exercises,
    Guid? AvatarId = null
);

public record CreateExerciseRequest(
    Guid MotionId,
    int Speed,
    int Repetitions,
    int Duration,
    ExerciseType ExerciseType,
    Dictionary<string, object> CustomFields,
    Guid? AvatarId = null
);

public record UpdateWorkoutRequest(
    string Name,
    string Description,
    List<UpdateExerciseRequest> Exercises,
    Guid? AvatarId = null
);

public record UpdateExerciseRequest(
    Guid? ExerciseId, // Null for new exercises, existing ID for updates
    Guid MotionId,
    int Speed,
    int Repetitions,
    int Duration,
    ExerciseType ExerciseType,
    Dictionary<string, object> CustomFields,
    Guid? AvatarId = null
);