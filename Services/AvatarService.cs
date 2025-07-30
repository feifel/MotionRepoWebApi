using MotionRepoServer.Models;

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
        InitializeSampleData();
    }

    private void InitializeSampleData()
    {
        _avatars.AddRange(new List<Avatar>
        {
            new Avatar("MaleBot.glb", "Male Bot", "A male robot avatar", "Male", new[] { "Robotics", "Technology" }) 
            { 
                Id = Guid.Parse("904d91dc-f6cf-4da6-a0cc-becdd51ac64f") 
            },
            new Avatar("FemaleBot.glb", "Female Bot", "A female robot avatar", "Female", new[] { "Robotics", "Technology" }) 
            { 
                Id = Guid.Parse("98fd82e0-c4a6-46cf-9b60-28150eed3ffd") 
            },
            new Avatar("Ninja.glb", "Shadow Ninja", "A stealthy ninja warrior avatar", "Male", new[] { "Fantasy", "Stealth" }) 
            { 
                Id = Guid.Parse("e66fb150-f748-4dfa-a4cb-b12c8ba1ea25") 
            },
            new Avatar("Maria.glb", "Maria", "A friendly female character avatar", "Female", new[] { "Realistic", "Casual" }) 
            { 
                Id = Guid.Parse("e32a46ec-6546-4f44-a517-1b2f6c960827") 
            },
            new Avatar("Knight.glb", "Sir Galahad", "A noble medieval knight in shining armor", "Male", new[] { "Fantasy", "Historical", "Medieval" }),
            new Avatar("Wizard.glb", "Merlin", "A wise old wizard with magical powers", "Male", new[] { "Fantasy", "Magic" }),
            new Avatar("Elf.glb", "Elara", "An elegant elven archer", "Female", new[] { "Fantasy", "Archery" }),
            new Avatar("Pirate.glb", "Captain Blackbeard", "A fearsome pirate captain", "Male", new[] { "Adventure", "Historical", "Maritime" }),
            new Avatar("Astronaut.glb", "Commander Nova", "A space explorer in advanced suit", "Female", new[] { "Sci-Fi", "Space", "Technology" }),
            new Avatar("Cyborg.glb", "Unit-X7", "A half-human, half-machine warrior", "Male", new[] { "Sci-Fi", "Technology", "Cyberpunk" }),
            new Avatar("Samurai.glb", "Akira", "A honorable Japanese warrior", "Male", new[] { "Historical", "Japanese", "Warrior" }),
            new Avatar("Viking.glb", "Freydis", "A fierce Norse warrior maiden", "Female", new[] { "Historical", "Norse", "Warrior" }),
            new Avatar("Mage.glb", "Seraphina", "A powerful sorceress of light magic", "Female", new[] { "Fantasy", "Magic", "Light" }),
            new Avatar("Soldier.glb", "Sergeant Steel", "A modern military operative", "Male", new[] { "Military", "Modern", "Combat" }),
            new Avatar("Medic.glb", "Dr. Hope", "A battlefield medic and healer", "Female", new[] { "Military", "Medical", "Support" }),
            new Avatar("Alien.glb", "Zyx-9", "An extraterrestrial being from distant worlds", "Non-Binary", new[] { "Sci-Fi", "Alien", "Exotic" }),
            new Avatar("Barbarian.glb", "Thorgar", "A mighty warrior from the frozen north", "Male", new[] { "Fantasy", "Warrior", "Tribal" }),
            new Avatar("Assassin.glb", "Shadow", "A deadly silent killer", "Female", new[] { "Stealth", "Combat", "Dark" }),
            new Avatar("Engineer.glb", "Gearhead", "A tech-savvy mechanical expert", "Male", new[] { "Industrial", "Technology", "Engineering" }),
            new Avatar("Dancer.glb", "Luna", "A graceful performer and entertainer", "Female", new[] { "Artistic", "Performance", "Entertainment" })
        });
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