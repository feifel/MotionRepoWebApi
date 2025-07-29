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
            },
            new Motion
            {
                Name = "Jumping Jack Animation",
                Description = "Classic jumping jack cardio exercise",
                File = "jumping_jack.fbx",
                FileType = "FBX",
                Screenshot = "jumping_jack_screenshot.jpg",
                Level = 1,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "FullBody" },
                MuscleGroups = new[] { "Legs", "Arms", "Core" },
                Categories = new[] { "Cardio", "FullBody" },
                PrimaryJoints = new[] { "Shoulder", "Hip", "Knee", "Ankle" },
                Labels = new[] { "JumpingJack", "Cardio", "FullBody" }
            },
            new Motion
            {
                Name = "Leg Raise Animation",
                Description = "Supine leg raises for lower abs",
                File = "leg_raise.fbx",
                FileType = "FBX",
                Screenshot = "leg_raise_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Core", "Legs" },
                MuscleGroups = new[] { "LowerAbs", "HipFlexors" },
                Categories = new[] { "Strength", "Core" },
                PrimaryJoints = new[] { "Hip", "Knee" },
                Labels = new[] { "LegRaise", "Core", "LowerAbs" }
            },
            new Motion
            {
                Name = "Hip Thrust Animation",
                Description = "Glute bridge hip thrust exercise",
                File = "hip_thrust.fbx",
                FileType = "FBX",
                Screenshot = "hip_thrust_screenshot.jpg",
                Level = 3,
                Equipment = new[] { "Barbell" },
                BodyParts = new[] { "Glutes", "Legs", "Core" },
                MuscleGroups = new[] { "Glutes", "Hamstrings", "Core" },
                Categories = new[] { "Strength", "Glutes", "LowerBody" },
                PrimaryJoints = new[] { "Hip", "Knee", "Spine" },
                Labels = new[] { "HipThrust", "Glutes", "Strength" }
            },
            new Motion
            {
                Name = "Wall Sit Animation",
                Description = "Isometric wall sit for leg endurance",
                File = "wall_sit.fbx",
                FileType = "FBX",
                Screenshot = "wall_sit_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Legs", "Core" },
                MuscleGroups = new[] { "Quads", "Glutes", "Core" },
                Categories = new[] { "Isometric", "Strength", "LowerBody" },
                PrimaryJoints = new[] { "Knee", "Hip" },
                Labels = new[] { "WallSit", "Legs", "Isometric" }
            },
            new Motion
            {
                Name = "Jump Rope Animation",
                Description = "Classic jump rope cardio workout",
                File = "jump_rope.fbx",
                FileType = "FBX",
                Screenshot = "jump_rope_screenshot.jpg",
                Level = 3,
                Equipment = new[] { "JumpRope" },
                BodyParts = new[] { "FullBody" },
                MuscleGroups = new[] { "Legs", "Arms", "Core" },
                Categories = new[] { "Cardio", "FullBody" },
                PrimaryJoints = new[] { "Wrist", "Shoulder", "Hip", "Knee" },
                Labels = new[] { "JumpRope", "Cardio", "FullBody" }
            },
            new Motion
            {
                Name = "Chest Fly Animation",
                Description = "Dumbbell chest fly exercise",
                File = "chest_fly.fbx",
                FileType = "FBX",
                Screenshot = "chest_fly_screenshot.jpg",
                Level = 3,
                Equipment = new[] { "Dumbbells" },
                BodyParts = new[] { "Chest", "Arms", "Shoulders" },
                MuscleGroups = new[] { "Chest", "Shoulders", "Arms" },
                Categories = new[] { "Strength", "UpperBody", "Isolation" },
                PrimaryJoints = new[] { "Shoulder", "Elbow" },
                Labels = new[] { "ChestFly", "Chest", "Isolation" }
            },
            new Motion
            {
                Name = "Side Plank Animation",
                Description = "Side plank hold for oblique strength",
                File = "side_plank.fbx",
                FileType = "FBX",
                Screenshot = "side_plank_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Core", "Obliques" },
                MuscleGroups = new[] { "Obliques", "Core" },
                Categories = new[] { "Strength", "Core", "Isometric" },
                PrimaryJoints = new[] { "Spine" },
                Labels = new[] { "SidePlank", "Core", "Obliques" }
            },
            new Motion
            {
                Name = "Cable Row Animation",
                Description = "Cable row exercise for back strength",
                File = "cable_row.fbx",
                FileType = "FBX",
                Screenshot = "cable_row_screenshot.jpg",
                Level = 3,
                Equipment = new[] { "CableMachine" },
                BodyParts = new[] { "Back", "Arms" },
                MuscleGroups = new[] { "Lats", "Biceps", "Rhomboids" },
                Categories = new[] { "Strength", "UpperBody", "Compound" },
                PrimaryJoints = new[] { "Shoulder", "Elbow" },
                Labels = new[] { "CableRow", "Back", "Strength" }
            },
            new Motion
            {
                Name = "Leg Extension Animation",
                Description = "Leg extension machine exercise for quads",
                File = "leg_extension.fbx",
                FileType = "FBX",
                Screenshot = "leg_extension_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "LegExtensionMachine" },
                BodyParts = new[] { "Legs" },
                MuscleGroups = new[] { "Quads" },
                Categories = new[] { "Strength", "Legs", "Isolation" },
                PrimaryJoints = new[] { "Knee" },
                Labels = new[] { "LegExtension", "Quads", "Isolation" }
            },
            new Motion
            {
                Name = "Flutter Kick Animation",
                Description = "Lying flutter kicks for core endurance",
                File = "flutter_kick.fbx",
                FileType = "FBX",
                Screenshot = "flutter_kick_screenshot.jpg",
                Level = 1,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Core", "Legs" },
                MuscleGroups = new[] { "Core", "HipFlexors" },
                Categories = new[] { "Strength", "Core", "Endurance" },
                PrimaryJoints = new[] { "Hip", "Knee" },
                Labels = new[] { "FlutterKick", "Core", "Endurance" }
            },
            new Motion
            {
                Name = "Side Lunge Animation",
                Description = "Lateral side lunge movement",
                File = "side_lunge.fbx",
                FileType = "FBX",
                Screenshot = "side_lunge_screenshot.jpg",
                Level = 3,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Legs", "Glutes", "Core" },
                MuscleGroups = new[] { "Quads", "Glutes", "Hamstrings" },
                Categories = new[] { "Strength", "LowerBody", "Balance" },
                PrimaryJoints = new[] { "Knee", "Hip", "Ankle" },
                Labels = new[] { "SideLunge", "Legs", "Balance" }
            },
            new Motion
            {
                Name = "Farmer's Walk Animation",
                Description = "Carrying weights while walking for strength",
                File = "farmers_walk.fbx",
                FileType = "FBX",
                Screenshot = "farmers_walk_screenshot.jpg",
            },
            new Motion
            {
                Name = "Yoga Sun Salutation Animation",
                Description = "Flowing yoga sequence connecting breath with movement",
                File = "sun_salutation.fbx",
                FileType = "FBX",
                Screenshot = "sun_salutation_screenshot.jpg",
                Level = 1,
                Equipment = new[] { "YogaMat" },
                BodyParts = new[] { "FullBody" },
                MuscleGroups = new[] { "Core", "Shoulders", "Legs", "Back" },
                Categories = new[] { "Flexibility", "Balance", "Mindfulness" },
                PrimaryJoints = new[] { "Spine", "Shoulder", "Hip", "Knee" },
                Labels = new[] { "Yoga", "Flow", "Flexibility", "SunSalutation" }
            },
            new Motion
            {
                Name = "Pilates Roll-Up Animation",
                Description = "Controlled spinal articulation exercise",
                File = "pilates_roll_up.fbx",
                FileType = "FBX",
                Screenshot = "pilates_roll_up_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "YogaMat" },
                BodyParts = new[] { "Core", "Spine" },
                MuscleGroups = new[] { "RectusAbdominis", "TransverseAbdominis", "SpinalErectors" },
                Categories = new[] { "Core", "Flexibility", "Control" },
                PrimaryJoints = new[] { "Spine" },
                Labels = new[] { "Pilates", "Core", "Spine", "Control" }
            },
            new Motion
            {
                Name = "Wall Ball Animation",
                Description = "Wall ball throw exercise with medicine ball",
                File = "wall_ball.fbx",
                FileType = "FBX",
                Screenshot = "wall_ball_screenshot.jpg",
                Level = 4,
                Equipment = new[] { "MedicineBall" },
                BodyParts = new[] { "FullBody" },
                MuscleGroups = new[] { "Legs", "Core", "Shoulders", "Arms" },
                Categories = new[] { "Strength", "Cardio", "FullBody" },
                PrimaryJoints = new[] { "Knee", "Hip", "Shoulder", "Elbow" },
                Labels = new[] { "WallBall", "Cardio", "Strength" }
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

    public List<string> GetMotionTags()
    {
        var tags = new HashSet<string>();

        foreach (var motion in _motions)
        {
            // Add Level tag
            tags.Add($"level:{motion.Level}");

            // Add Equipment tags
            if (motion.Equipment != null)
            {
                foreach (var equipment in motion.Equipment)
                {
                    if (!string.IsNullOrEmpty(equipment))
                    {
                        tags.Add($"equipment:{equipment}");
                    }
                }
            }

            // Add BodyParts tags
            if (motion.BodyParts != null)
            {
                foreach (var bodyPart in motion.BodyParts)
                {
                    if (!string.IsNullOrEmpty(bodyPart))
                    {
                        tags.Add($"bodypart:{bodyPart}");
                    }
                }
            }

            // Add MuscleGroups tags
            if (motion.MuscleGroups != null)
            {
                foreach (var muscleGroup in motion.MuscleGroups)
                {
                    if (!string.IsNullOrEmpty(muscleGroup))
                    {
                        tags.Add($"musclegroup:{muscleGroup}");
                    }
                }
            }

            // Add Categories tags
            if (motion.Categories != null)
            {
                foreach (var category in motion.Categories)
                {
                    if (!string.IsNullOrEmpty(category))
                    {
                        tags.Add($"category:{category}");
                    }
                }
            }

            // Add PrimaryJoints tags
            if (motion.PrimaryJoints != null)
            {
                foreach (var joint in motion.PrimaryJoints)
                {
                    if (!string.IsNullOrEmpty(joint))
                    {
                        tags.Add($"primaryjoint:{joint}");
                    }
                }
            }

            // Add Labels tags
            if (motion.Labels != null)
            {
                foreach (var label in motion.Labels)
                {
                    if (!string.IsNullOrEmpty(label))
                    {
                        tags.Add($"label:{label}");
                    }
                }
            }
        }

        return tags.OrderBy(t => t).ToList();
    }
}