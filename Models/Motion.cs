using MotionRepoServer.Models.Enums;

namespace MotionRepoServer.Models;

public record Motion
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string File { get; init; } = string.Empty;
    public string FileType { get; init; } = string.Empty;
    public string Screenshot { get; init; } = string.Empty;
    public int Level { get; init; }
    public string[] Equipment { get; init; } = Array.Empty<string>();
    public string[] BodyParts { get; init; } = Array.Empty<string>();
    public string[] MuscleGroups { get; init; } = Array.Empty<string>();
    public string[] Categories { get; init; } = Array.Empty<string>();
    public string[] PrimaryJoints { get; init; } = Array.Empty<string>();
    public string[] Labels { get; init; } = Array.Empty<string>();
}

public record CreateMotionRequest(
    string Name,
    string Description,
    string File,
    string FileType,
    string Screenshot,
    int Level,
    string[] Equipment,
    string[] BodyParts,
    string[] MuscleGroups,
    string[] Categories,
    string[] PrimaryJoints,
    string[] Labels
);

public record UpdateMotionRequest(
    string Name,
    string Description,
    string File,
    string FileType,
    string Screenshot,
    int Level,
    string[] Equipment,
    string[] BodyParts,
    string[] MuscleGroups,
    string[] Categories,
    string[] PrimaryJoints,
    string[] Labels
);