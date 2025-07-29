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
        var motions = _motionService.GetMotions(0, 50, null, null).Data.ToList();
        if (!motions.Any())
            return;

        var workouts = new List<Workout>
        {
            // 1. Morning Warm-up Routine
            new Workout
            {
                Name = "Morning Warm-up Routine",
                Description = "A quick 10-minute warm-up routine to start your day with energy and flexibility",
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
                            { "intensity", "low" },
                            { "notes", "Focus on smooth, controlled movements" }
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
                            { "weight", 0.0 },
                            { "rest_time", 15 }
                        }
                    }
                }
            },

            // 2. HIIT Cardio Blast
            new Workout
            {
                Name = "HIIT Cardio Blast",
                Description = "High-intensity interval training for maximum calorie burn in minimum time",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(2).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 3,
                        Repetitions = 20,
                        Duration = 45,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "rounds", 4 },
                            { "rest_between_rounds", 60 }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(3).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 15,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "modification", "jump version" }
                        }
                    }
                }
            },

            // 3. Strength Foundation
            new Workout
            {
                Name = "Strength Foundation",
                Description = "Build fundamental strength with compound movements and progressive overload",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(4).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 8,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 20.0 },
                            { "sets", 3 },
                            { "rest_between_sets", 90 }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(5).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 10,
                        Duration = 60,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 15.0 },
                            { "sets", 3 },
                            { "tempo", "2-1-2" }
                        }
                    }
                }
            },

            // 4. Core & Stability
            new Workout
            {
                Name = "Core & Stability",
                Description = "Strengthen your core and improve balance with targeted stability exercises",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(6).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 1,
                        Duration = 60,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", 3 },
                            { "focus", "control and breathing" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(7).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 12,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "variation", "alternating" }
                        }
                    }
                }
            },

            // 5. Flexibility & Mobility
            new Workout
            {
                Name = "Flexibility & Mobility",
                Description = "Improve range of motion and reduce muscle tension with dynamic stretching",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(8).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 1,
                        Duration = 90,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "sets", 2 },
                            { "breathing", "deep and controlled" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(9).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 8,
                        Duration = 60,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "hold_time", 30 }
                        }
                    }
                }
            },

            // 6. Upper Body Power
            new Workout
            {
                Name = "Upper Body Power",
                Description = "Develop explosive upper body strength with plyometric and power movements",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(0).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 3,
                        Repetitions = 6,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 10.0 },
                            { "sets", 4 },
                            { "explosiveness", "maximum" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(1).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 8,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 12.5 },
                            { "sets", 3 },
                            { "tempo", "explosive up, slow down" }
                        }
                    }
                }
            },

            // 7. Lower Body Burn
            new Workout
            {
                Name = "Lower Body Burn",
                Description = "Target glutes, quads, and hamstrings with intense lower body focus",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(2).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 12,
                        Duration = 60,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 25.0 },
                            { "sets", 3 },
                            { "depth", "full range" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(3).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 15,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 20.0 },
                            { "sets", 3 },
                            { "variation", "single leg" }
                        }
                    }
                }
            },

            // 8. Yoga Flow
            new Workout
            {
                Name = "Yoga Flow",
                Description = "Connect mind and body with flowing yoga sequences for balance and flexibility",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(4).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 1,
                        Duration = 120,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "breathing", "ujjayi breath" },
                            { "flow", "continuous movement" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(5).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 5,
                        Duration = 90,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "mindfulness", "present moment awareness" }
                        }
                    }
                }
            },

            // 9. Functional Fitness
            new Workout
            {
                Name = "Functional Fitness",
                Description = "Train movements that translate to everyday activities and sports performance",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(6).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 10,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 15.0 },
                            { "sets", 3 },
                            { "real_world_application", "lifting groceries" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(7).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 12,
                        Duration = 40,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 10.0 },
                            { "sets", 3 },
                            { "balance_challenge", "unstable surface" }
                        }
                    }
                }
            },

            // 10. Endurance Builder
            new Workout
            {
                Name = "Endurance Builder",
                Description = "Build cardiovascular endurance and muscular stamina for long-duration activities",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(8).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 1,
                        Duration = 300,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "moderate" },
                            { "heart_rate_zone", "65-75% max" },
                            { "progression", "increase by 5 min weekly" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(9).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 1,
                        Duration = 180,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "moderate-high" },
                            { "interval_training", "steady pace" }
                        }
                    }
                }
            },

            // 11. Beginner Full Body
            new Workout
            {
                Name = "Beginner Full Body",
                Description = "Perfect starting point for fitness beginners with basic compound movements",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(0).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 8,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 5.0 },
                            { "sets", 2 },
                            { "focus", "form over weight" }
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
                            { "weight", 0.0 },
                            { "sets", 2 },
                            { "modification", "bodyweight" }
                        }
                    }
                }
            },

            // 12. Advanced Athlete
            new Workout
            {
                Name = "Advanced Athlete",
                Description = "Challenge elite fitness levels with complex movements and high intensity",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(2).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 3,
                        Repetitions = 5,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 40.0 },
                            { "sets", 5 },
                            { "complexity", "advanced" },
                            { "rest", "2-3 minutes" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(3).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 3,
                        Repetitions = 8,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 30.0 },
                            { "sets", 4 },
                            { "superset", "with plyometrics" }
                        }
                    }
                }
            },

            // 13. Rehabilitation
            new Workout
            {
                Name = "Rehabilitation",
                Description = "Gentle recovery exercises for injury prevention and rehabilitation",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(4).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 15,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 2.0 },
                            { "sets", 2 },
                            { "pain_scale", "0-3 acceptable" },
                            { "focus", "controlled movement" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(5).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 12,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 0.0 },
                            { "sets", 3 },
                            { "range_of_motion", "pain-free" }
                        }
                    }
                }
            },

            // 14. Sports Specific
            new Workout
            {
                Name = "Sports Specific",
                Description = "Train movement patterns specific to athletic performance and sports skills",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(6).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 3,
                        Repetitions = 8,
                        Duration = 20,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 5.0 },
                            { "sets", 4 },
                            { "sport", "basketball" },
                            { "explosiveness", "maximum" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(7).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 10,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 10.0 },
                            { "sets", 3 },
                            { "agility", "lateral movement" }
                        }
                    }
                }
            },

            // 15. Weight Loss Circuit
            new Workout
            {
                Name = "Weight Loss Circuit",
                Description = "High-calorie burn circuit training for effective weight management",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(8).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 20,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 0.0 },
                            { "sets", 3 },
                            { "circuit_rest", 30 },
                            { "calories_burned", "200-300" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(9).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 15,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 5.0 },
                            { "sets", 3 },
                            { "metabolic_boost", "high" }
                        }
                    }
                }
            },

            // 16. Senior Fitness
            new Workout
            {
                Name = "Senior Fitness",
                Description = "Safe and effective exercises designed specifically for older adults",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(0).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 10,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 3.0 },
                            { "sets", 2 },
                            { "chair_support", "optional" },
                            { "balance", "improve stability" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(1).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 12,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 0.0 },
                            { "sets", 2 },
                            { "joint_health", "focus on mobility" }
                        }
                    }
                }
            },

            // 17. Prenatal Safe
            new Workout
            {
                Name = "Prenatal Safe",
                Description = "Gentle and safe exercises for expectant mothers during pregnancy",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(2).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 12,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 0.0 },
                            { "sets", 2 },
                            { "trimester_safe", "all trimesters" },
                            { "pelvic_floor", "engage gently" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(3).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 10,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 0.0 },
                            { "sets", 2 },
                            { "back_support", "prevent strain" }
                        }
                    }
                }
            },

            // 18. Desk Worker Relief
            new Workout
            {
                Name = "Desk Worker Relief",
                Description = "Counteract the negative effects of prolonged sitting with targeted stretches",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(4).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 1,
                        Duration = 60,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "sets", 3 },
                            { "posture_correction", "focus on shoulders" },
                            { "office_friendly", "can be done at desk" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(5).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 15,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "sets", 2 },
                            { "neck_relief", "reduce tension" }
                        }
                    }
                }
            },

            // 19. Weekend Warrior
            new Workout
            {
                Name = "Weekend Warrior",
                Description = "Intense full-body workout for those who train primarily on weekends",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(6).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 15,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 20.0 },
                            { "sets", 4 },
                            { "intensity", "high" },
                            { "recovery_importance", "prioritize rest" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(7).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 12,
                        Duration = 60,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "weight", 25.0 },
                            { "sets", 3 },
                            { "compound_movement", "multiple muscle groups" }
                        }
                    }
                }
            },

            // 20. Mindful Movement
            new Workout
            {
                Name = "Mindful Movement",
                Description = "Combine physical exercise with mental focus for holistic wellness",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.Skip(8).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 1,
                        Duration = 120,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "mindfulness", "body awareness" },
                            { "breathing_technique", "coordinated with movement" },
                            { "stress_relief", "primary goal" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.Skip(9).FirstOrDefault()?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 8,
                        Duration = 90,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "meditation", "moving meditation" },
                            { "grounding", "feel connected to earth" }
                        }
                    }
                }
            }
        };

        _workouts.AddRange(workouts);
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