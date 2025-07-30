using MotionRepoServer.Models;
using MotionRepoServer.Data;

namespace MotionRepoServer.Services;

public class AvatarService
{
    private readonly List<Avatar> _avatars;
    private readonly GitHubRepositoryService _gitHubService;
    private bool _initialized = false;

    public AvatarService(GitHubRepositoryService gitHubService)
    {
        _gitHubService = gitHubService;
        _avatars = new List<Avatar>();
        
        // Initialize with sample data as fallback
        _avatars.AddRange(AvatarSampleData.GetSampleAvatars());
    }

    public async Task InitializeAsync()
    {
        if (_initialized) return;

        if (_gitHubService.IsConfigured)
        {
            var githubAvatars = await _gitHubService.LoadAvatarsAsync();
            if (githubAvatars.Any())
            {
                _avatars.Clear();
                _avatars.AddRange(githubAvatars);
            }
        }

        _initialized = true;
    }

    public PagedResponse<Avatar> GetAvatars(int? offset, int? limit, string? tags, string? search)
    {
        var filteredAvatars = _avatars.AsEnumerable();

        // Filter by text if provided (search in Name, Description, Gender, Categories)
        if (!string.IsNullOrWhiteSpace(search))
        {
            var searchWords = search.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(word => word.Trim().ToLowerInvariant())
                                 .Where(word => !string.IsNullOrEmpty(word))
                                 .ToList();

            if (searchWords.Any())
            {
                filteredAvatars = filteredAvatars.Where(a =>
                {
                    var categoriesText = string.Join(" ", a.Categories).ToLowerInvariant();
                    var combinedText = $"{a.Name} {a.Description} {a.Gender} {categoriesText}".ToLowerInvariant();
                    return searchWords.All(word => combinedText.Contains(word));
                });
            }
        }

        // Filter by tags if provided (format: prefix:postfix where prefix is "Gender" or "Category")
        if (!string.IsNullOrWhiteSpace(tags))
        {
            var tagList = tags.Split(',', StringSplitOptions.RemoveEmptyEntries)
                             .Select(tag => tag.Trim())
                             .Where(tag => !string.IsNullOrEmpty(tag))
                             .ToList();

            if (tagList.Any())
            {
                filteredAvatars = filteredAvatars.Where(a =>
                {
                    return tagList.All(tag =>
                    {
                        var parts = tag.Split(':', 2, StringSplitOptions.None);
                        if (parts.Length != 2)
                        {
                            // Invalid format, skip this tag
                            return true;
                        }

                        var prefix = parts[0].Trim().ToLowerInvariant();
                        var postfix = parts[1].Trim().ToLowerInvariant();

                        if (string.IsNullOrEmpty(postfix))
                        {
                            // Empty postfix, skip this tag
                            return true;
                        }

                        return prefix switch
                        {
                            "gender" => a.Gender.ToLowerInvariant().Contains(postfix),
                            "categories" => a.Categories.Any(cat => cat.ToLowerInvariant().Contains(postfix)),
                            _ => true // Unknown prefix, skip this tag
                        };
                    });
                });
            }
        }

        // Get total count before pagination
        var totalCount = filteredAvatars.Count();

        // Apply pagination
        var skip = Math.Max(0, offset ?? 0);
        var take = Math.Max(1, Math.Min(100, limit ?? 10)); // Default to 10 if not specified

        var pagedData = filteredAvatars.Skip(skip).Take(take).ToArray();

        Console.WriteLine($"FilteredAvatars: {totalCount}, skip {skip}, take {take} -> return: {pagedData.Length}");

        return new PagedResponse<Avatar>(pagedData, totalCount, skip, take);
    }

    public Avatar? GetAvatarById(Guid id)
    {
        return _avatars.FirstOrDefault(a => a.Id == id);
    }

    public Avatar CreateAvatar(CreateAvatarRequest request)
    {
        var avatar = new Avatar(request.FileName, request.Name, request.Description, request.Gender, request.Categories);
        _avatars.Add(avatar);
        return avatar;
    }

    public Avatar? UpdateAvatar(Guid id, UpdateAvatarRequest request)
    {
        var existingAvatar = _avatars.FirstOrDefault(a => a.Id == id);
        if (existingAvatar == null)
            return null;

        var updatedAvatar = new Avatar(request.FileName, request.Name, request.Description, request.Gender, request.Categories)
        {
            Id = id
        };

        var index = _avatars.FindIndex(a => a.Id == id);
        _avatars[index] = updatedAvatar;

        return updatedAvatar;
    }

    public bool DeleteAvatar(Guid id)
    {
        var avatar = _avatars.FirstOrDefault(a => a.Id == id);
        if (avatar == null)
            return false;

        _avatars.Remove(avatar);
        return true;
    }

    public List<string> GetAvatarTags()
    {
        var tags = new List<string>();

        foreach (var avatar in _avatars)
        {
            tags.AddRange(avatar.Categories.Select(c => $"category:{c}"));
            tags.Add($"gender:{avatar.Gender}");
        }

        return tags.Distinct().OrderBy(t => t).ToList();
    }
}