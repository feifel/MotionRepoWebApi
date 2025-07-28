using MotionRepoServer.Models;

namespace MotionRepoServer.Services;

public class AvatarService
{
    private readonly List<Avatar> _avatars;

    public AvatarService()
    {
        _avatars = new List<Avatar>
        {
            new Avatar("MaleBot.glb", "Male Bot", "A male robot avatar", "Male", new[] { "Robotics", "Technology" }),
            new Avatar("FemaleBot.glb", "Female Bot", "A female robot avatar", "Female", new[] { "Robotics", "Technology" }),
            new Avatar("Ninja.glb", "Shadow Ninja", "A stealthy ninja warrior avatar", "Male", new[] { "Fantasy", "Stealth" }),
            new Avatar("Maria.glb", "Maria", "A friendly female character avatar", "Female", new[] { "Realistic", "Casual" }),
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
        };
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
                            "category" => a.Categories.Any(cat => cat.ToLowerInvariant().Contains(postfix)),
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

        Console.WriteLine($"FilteredAvatars: {totalCount}, skip {skip}, take {take}");

        var pagedData = filteredAvatars.Skip(skip).Take(take).ToArray();

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
        var existingAvatarIndex = _avatars.FindIndex(a => a.Id == id);
        if (existingAvatarIndex == -1)
        {
            return null;
        }

        var updatedAvatar = _avatars[existingAvatarIndex] with
        {
            FileName = request.FileName,
            Name = request.Name,
            Description = request.Description,
            Gender = request.Gender,
            Categories = request.Categories
        };

        _avatars[existingAvatarIndex] = updatedAvatar;
        return updatedAvatar;
    }

    public bool DeleteAvatar(Guid id)
    {
        var avatarIndex = _avatars.FindIndex(a => a.Id == id);
        if (avatarIndex == -1)
        {
            return false;
        }

        _avatars.RemoveAt(avatarIndex);
        return true;
    }
}