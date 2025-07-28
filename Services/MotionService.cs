using MotionRepoServer.Models;

namespace MotionRepoServer.Services;

public class MotionService
{
    private readonly List<Motion> _motions;

    public MotionService()
    {
        _motions = new List<Motion>
        {
            new Motion
            {
                Name = "Walking Animation",
                Description = "Basic walking cycle animation",
                File = "walk.fbx",
                FileType = "FBX",
                Screenshot = "walk_screenshot.jpg",
                Level = 1,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Legs", "Arms" },
                MuscleGroups = new[] { "Calves", "Quads", "Hamstrings" },
                Categories = new[] { "Locomotion" },
                PrimaryJoints = new[] { "Knee", "Ankle", "Hip" },
                Labels = new[] { "Walk", "Basic", "Cycle" }
            },
            new Motion
            {
                Name = "Running Animation",
                Description = "Fast running cycle animation",
                File = "run.fbx",
                FileType = "FBX",
                Screenshot = "run_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Legs", "Arms", "Core" },
                MuscleGroups = new[] { "Calves", "Quads", "Hamstrings", "Glutes" },
                Categories = new[] { "Locomotion", "Cardio" },
                PrimaryJoints = new[] { "Knee", "Ankle", "Hip" },
                Labels = new[] { "Run", "Fast", "Cycle" }
            },
            new Motion
            {
                Name = "Jump Animation",
                Description = "Character jumping animation",
                File = "jump.fbx",
                FileType = "FBX",
                Screenshot = "jump_screenshot.jpg",
                Level = 3,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Legs", "Core" },
                MuscleGroups = new[] { "Quads", "Calves", "Glutes" },
                Categories = new[] { "Action", "Plyometric" },
                PrimaryJoints = new[] { "Knee", "Ankle", "Hip" },
                Labels = new[] { "Jump", "Action", "Movement" }
            },
            new Motion
            {
                Name = "Idle Animation",
                Description = "Character idle pose animation",
                File = "idle.fbx",
                FileType = "FBX",
                Screenshot = "idle_screenshot.jpg",
                Level = 0,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "FullBody" },
                MuscleGroups = new[] { "Core" },
                Categories = new[] { "Idle" },
                PrimaryJoints = new[] { "Spine" },
                Labels = new[] { "Idle", "Rest", "Standing" }
            },
            new Motion
            {
                Name = "Dance Animation",
                Description = "Rhythmic dance moves",
                File = "dance.fbx",
                FileType = "FBX",
                Screenshot = "dance_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "FullBody" },
                MuscleGroups = new[] { "Core", "Arms", "Legs" },
                Categories = new[] { "Entertainment", "Cardio" },
                PrimaryJoints = new[] { "Hip", "Shoulder", "Spine" },
                Labels = new[] { "Dance", "Music", "Fun" }
            }
        };
    }

    public PagedResponse<Motion> GetMotions(int? offset, int? limit, string? tags, string? search)
    {
        var filteredMotions = _motions.AsEnumerable();

        // Filter by text if provided
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
                            "bodypart" => m.BodyParts.Any(bp => bp.ToLowerInvariant().Contains(postfix)),
                            "musclegroup" => m.MuscleGroups.Any(mg => mg.ToLowerInvariant().Contains(postfix)),
                            "primaryjoint" => m.PrimaryJoints.Any(pj => pj.ToLowerInvariant().Contains(postfix)),
                            "exercisetype" => m.Categories.Any(cat => cat.ToLowerInvariant().Contains(postfix)),
                            "equipment" => m.Equipment.Any(eq => eq.ToLowerInvariant().Contains(postfix)),
                            "level" => m.Level.ToString().Contains(postfix),
                            "label" => m.Labels.Any(lbl => lbl.ToLowerInvariant().Contains(postfix)),
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
        var existingMotionIndex = _motions.FindIndex(m => m.Id == id);
        if (existingMotionIndex == -1)
        {
            return null;
        }

        var updatedMotion = _motions[existingMotionIndex] with
        {
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

        _motions[existingMotionIndex] = updatedMotion;
        return updatedMotion;
    }

    public bool DeleteMotion(Guid id)
    {
        var motionIndex = _motions.FindIndex(m => m.Id == id);
        if (motionIndex == -1)
        {
            return false;
        }

        _motions.RemoveAt(motionIndex);
        return true;
    }
}