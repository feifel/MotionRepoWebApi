using MotionRepoServer.Models;

namespace MotionRepoServer.Services;

public class MotionService
{
    private readonly List<Motion> _motions;
    private readonly GitHubRepositoryService _gitHubService;
    private bool _initialized = false;

    public MotionService(GitHubRepositoryService gitHubService)
    {
        _gitHubService = gitHubService;
        _motions = new List<Motion>();
        
        // Initialize with sample data as fallback
        InitializeSampleData();
    }

    private void InitializeSampleData()
    {
        _motions.AddRange(new List<Motion>
        {
            new Motion
            {
                Id = Guid.Parse("23b03363-3b5f-4a5e-804b-8d490f8e51e6"),
                Name = "Air Squat",
                Description = "Basic air squat exercise",
                File = "AirSquat.glb",
                FileType = "GLB",
                Screenshot = "air_squat_screenshot.jpg",
                Level = 1,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Legs", "Glutes" },
                MuscleGroups = new[] { "Quads", "Hamstrings", "Glutes" },
                Categories = new[] { "Strength", "LowerBody" },
                PrimaryJoints = new[] { "Knee", "Hip", "Ankle" },
                Labels = new[] { "Squat", "Bodyweight", "Basic" }
            },
            new Motion
            {
                Id = Guid.Parse("7d4e601f-af24-4fd8-b37e-5f26a12e1ba2"),
                Name = "Laying On The Floor",
                Description = "Resting position laying on the floor",
                File = "LayingOnTheFloor.glb",
                FileType = "GLB",
                Screenshot = "laying_screenshot.jpg",
                Level = 1,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "FullBody" },
                MuscleGroups = new[] { "Core" },
                Categories = new[] { "Rest", "Recovery" },
                PrimaryJoints = new[] { "Spine", "Hip" },
                Labels = new[] { "Rest", "Floor", "Recovery" }
            },
            new Motion
            {
                Id = Guid.Parse("7ef293cb-383b-41ba-8085-049064cbbc73"),
                Name = "Pushup",
                Description = "Standard pushup exercise",
                File = "Pushup.glb",
                FileType = "GLB",
                Screenshot = "pushup_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Chest", "Arms", "Core" },
                MuscleGroups = new[] { "Chest", "Triceps", "Shoulders", "Core" },
                Categories = new[] { "Strength", "UpperBody" },
                PrimaryJoints = new[] { "Shoulder", "Elbow", "Wrist" },
                Labels = new[] { "Pushup", "Bodyweight", "UpperBody" }
            },
            new Motion
            {
                Id = Guid.Parse("a2e4a2d5-bde4-4b3e-b376-ee3e1dbcbade"),
                Name = "Standing Pose",
                Description = "Basic standing idle pose",
                File = "StandingPose.glb",
                FileType = "GLB",
                Screenshot = "standing_screenshot.jpg",
                Level = 1,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "FullBody" },
                MuscleGroups = new[] { "Core" },
                Categories = new[] { "Pose", "Idle" },
                PrimaryJoints = new[] { "Spine", "Hip", "Knee", "Ankle" },
                Labels = new[] { "Standing", "Idle", "Pose" }
            },
            new Motion
            {
                Id = Guid.Parse("f7691059-c26d-4a3c-a45f-f8f9f0ab1436"),
                Name = "Sitting On The Floor",
                Description = "Sitting position on the floor",
                File = "SittingOnTheFlor.glb",
                FileType = "GLB",
                Screenshot = "sitting_screenshot.jpg",
                Level = 1,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "FullBody" },
                MuscleGroups = new[] { "Core", "HipFlexors" },
                Categories = new[] { "Pose", "Rest" },
                PrimaryJoints = new[] { "Hip", "Knee", "Ankle" },
                Labels = new[] { "Sitting", "Floor", "Rest" }
            }
        });
    }

    public async Task InitializeAsync()
    {
        if (_initialized) return;

        if (_gitHubService.IsConfigured)
        {
            var githubMotions = await _gitHubService.LoadMotionsAsync();
            if (githubMotions.Any())
            {
                _motions.Clear();
                _motions.AddRange(githubMotions);
            }
        }

        _initialized = true;
    }

    public PagedResponse<Motion> GetMotions(int? offset, int? limit, string? tags, string? search)
    {
        var filteredMotions = _motions.AsEnumerable();

        // Filter by tags if provided
        if (!string.IsNullOrWhiteSpace(search))
        {
            var searchWords = search.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(word => word.Trim().ToLowerInvariant())
                                 .Where(word => !string.IsNullOrEmpty(word))
                                 .ToList();

            if (searchWords.Any())
            {
                filteredMotions = filteredMotions.Where(m =>
                {
                    var labelsText = string.Join(" ", m.Labels).ToLowerInvariant();
                    var categoriesText = string.Join(" ", m.Categories).ToLowerInvariant();
                    var bodyPartsText = string.Join(" ", m.BodyParts).ToLowerInvariant();
                    var muscleGroupsText = string.Join(" ", m.MuscleGroups).ToLowerInvariant();
                    var equipmentText = string.Join(" ", m.Equipment).ToLowerInvariant();

                    var combinedText = $"{m.Name} {m.Description} {labelsText} {categoriesText} {bodyPartsText} {muscleGroupsText} {equipmentText}".ToLowerInvariant();
                    return searchWords.All(word => combinedText.Contains(word));
                });
            }
        }

        // Filter by tags if provided (format: prefix:postfix where prefix matches MotionTagType)
        if (!string.IsNullOrWhiteSpace(tags))
        {
            var tagList = tags.Split(',', StringSplitOptions.RemoveEmptyEntries)
                             .Select(tag => tag.Trim())
                             .Where(tag => !string.IsNullOrEmpty(tag))
                             .ToList();

            if (tagList.Any())
            {
                filteredMotions = filteredMotions.Where(m =>
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
                            "bodyparts" => m.BodyParts.Any(bp => bp.ToLowerInvariant().Contains(postfix)),
                            "musclegroups" => m.MuscleGroups.Any(mg => mg.ToLowerInvariant().Contains(postfix)),
                            "primaryjoints" => m.PrimaryJoints.Any(pj => pj.ToLowerInvariant().Contains(postfix)),
                            "exercisetype" => m.Categories.Any(cat => cat.ToLowerInvariant().Contains(postfix)),
                            "equipment" => m.Equipment.Any(eq => eq.ToLowerInvariant().Contains(postfix)),
                            "level" => m.Level.ToString().Contains(postfix),
                            "labels" => m.Labels.Any(lbl => lbl.ToLowerInvariant().Contains(postfix)),
                            _ => true // Unknown prefix, skip this tag
                        };
                    });
                });
            }
        }

        // Get total count before pagination
        var totalCount = filteredMotions.Count();

        // Apply pagination
        var skip = Math.Max(0, offset ?? 0);
        var take = Math.Max(1, Math.Min(100, limit ?? 10));

        var pagedData = filteredMotions.Skip(skip).Take(take).ToArray();

        return new PagedResponse<Motion>(pagedData, totalCount, skip, take);
    }

    public Motion? GetMotionById(Guid id)
    {
        return _motions.FirstOrDefault(m => m.Id == id);
    }

    public Motion CreateMotion(CreateMotionRequest request)
    {
        var motion = new Motion
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            File = request.File,
            FileType = request.FileType,
            Screenshot = request.Screenshot,
            Level = request.Level,
            Equipment = request.Equipment,
            BodyParts = request.BodyParts,
            MuscleGroups = request.MuscleGroups,
            Categories = request.Categories,
            PrimaryJoints = request.PrimaryJoints,
            Labels = request.Labels
        };

        _motions.Add(motion);
        return motion;
    }

    public Motion? UpdateMotion(Guid id, UpdateMotionRequest request)
    {
        var existingMotion = _motions.FirstOrDefault(m => m.Id == id);
        if (existingMotion == null)
            return null;

        var updatedMotion = new Motion
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            File = request.File,
            FileType = request.FileType,
            Screenshot = request.Screenshot,
            Level = request.Level,
            Equipment = request.Equipment,
            BodyParts = request.BodyParts,
            MuscleGroups = request.MuscleGroups,
            Categories = request.Categories,
            PrimaryJoints = request.PrimaryJoints,
            Labels = request.Labels
        };

        var index = _motions.FindIndex(m => m.Id == id);
        _motions[index] = updatedMotion;

        return updatedMotion;
    }

    public bool DeleteMotion(Guid id)
    {
        var motion = _motions.FirstOrDefault(m => m.Id == id);
        if (motion == null)
            return false;

        _motions.Remove(motion);
        return true;
    }

    public List<string> GetMotionTags()
    {
        var tags = new List<string>();

        foreach (var motion in _motions)
        {
            tags.AddRange(motion.Equipment.Select(e => $"equipment:{e}"));
            tags.AddRange(motion.BodyParts.Select(bp => $"bodypart:{bp}"));
            tags.AddRange(motion.MuscleGroups.Select(mg => $"musclegroup:{mg}"));
            tags.AddRange(motion.Categories.Select(c => $"category:{c}"));
            tags.AddRange(motion.PrimaryJoints.Select(pj => $"primaryjoint:{pj}"));
            tags.AddRange(motion.Labels.Select(l => $"label:{l}"));
            tags.Add($"level:{motion.Level}");
        }

        return tags.Distinct().OrderBy(t => t).ToList();
    }
}