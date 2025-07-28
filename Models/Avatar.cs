namespace MotionRepoServer.Models;

public record Avatar(string FileName, string Name, string Description, string Gender, string[] Categories)
{
    public Guid Id { get; init; } = Guid.NewGuid();
}

public record CreateAvatarRequest(string FileName, string Name, string Description, string Gender, string[] Categories);

public record UpdateAvatarRequest(string FileName, string Name, string Description, string Gender, string[] Categories);