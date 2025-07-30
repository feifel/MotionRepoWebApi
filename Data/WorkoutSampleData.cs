using MotionRepoServer.Models;

namespace MotionRepoServer.Data;

public static class WorkoutSampleData
{
    public static List<Workout> GetSampleWorkouts()
    {
        var motions = MotionSampleData.GetSampleMotions();
        
        return new List<Workout>
        {
            new Workout
            {
                Id = Guid.Parse("3313c09e-2f1e-4b19-bab2-aed759966b6f"),
                Name = "Morning Warm-up Routine",
                Description = "A quick 10-minute warm-up routine to start your day with energy and flexibility",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Standing Pose")?.Id ?? motions.First().Id,
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
                        MotionId = motions.FirstOrDefault(m => m.Name == "Air Squat")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 10,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "notes", "Keep your back straight and chest up" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("38d8baa2-c288-448c-8a44-98226e477a62"),
                Name = "Core Strength Builder",
                Description = "A focused core workout to build abdominal and lower back strength",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Pushup")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 15,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "notes", "Maintain proper plank position throughout" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Laying On The Floor")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 1,
                        Duration = 60,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "notes", "Use as active recovery between sets" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("4a5b6c7d-8e9f-0a1b-2c3d-4e5f6a7b8c9d"),
                Name = "HIIT Cardio Blast",
                Description = "High-intensity interval training workout to boost metabolism and burn calories",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Burpees")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 10,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "maximum" },
                            { "rest", "15 seconds" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Mountain Climbers")?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 20,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "rest", "15 seconds" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "High Knees")?.Id ?? motions.First().Id,
                        Speed = 2,
                        Repetitions = 30,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "rest", "30 seconds" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("5b6c7d8e-9f0a-1b2c-3d4e-5f6a7b8c9d0e"),
                Name = "Lower Body Strength",
                Description = "Build powerful legs and glutes with this targeted lower body routine",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Air Squat")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 15,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "3" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Lunges")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 12,
                        Duration = 40,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "3" },
                            { "each_leg", true }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Glute Bridge")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 20,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "3" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("6c7d8e9f-0a1b-2c3d-4e5f-6a7b8c9d0e1f"),
                Name = "Core & Abs Focus",
                Description = "Intense core workout targeting all abdominal muscles for definition and strength",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Plank")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 1,
                        Duration = 60,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "sets", "3" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Bicycle Crunches")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 20,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "3" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Russian Twists")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 30,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "3" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("7d8e9f0a-1b2c-3d4e-5f6a-7b8c9d0e1f2a"),
                Name = "Upper Body Pump",
                Description = "Build upper body strength and muscle with this comprehensive workout",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Pushup")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 15,
                        Duration = 40,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "4" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Dumbbell Rows")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 12,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "4" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Shoulder Press")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 10,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "4" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("8e9f0a1b-2c3d-4e5f-6a7b-8c9d0e1f2a3b"),
                Name = "Active Recovery Flow",
                Description = "Gentle movement and stretching for recovery days",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Standing Pose")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 1,
                        Duration = 60,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "very low" },
                            { "focus", "breathing and posture" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Sitting On The Floor")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 1,
                        Duration = 90,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "very low" },
                            { "focus", "gentle stretching" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Laying On The Floor")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 1,
                        Duration = 120,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "very low" },
                            { "focus", "complete relaxation" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("9f0a1b2c-3d4e-5f6a-7b8c-9d0e1f2a3b4c"),
                Name = "Quick Office Break",
                Description = "5-minute energizing workout you can do at your desk",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Jumping Jacks")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 20,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "space", "limited" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Wall Sit")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 1,
                        Duration = 45,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "2" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Calf Raises")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 25,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "sets", "2" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("a0a1b2c3-4d5e-6f7a-8b9c-0d1e2f3a4b5c"),
                Name = "Leg Day Essentials",
                Description = "Comprehensive leg workout for strength and muscle development",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Air Squat")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 20,
                        Duration = 60,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "sets", "4" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Lunges")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 15,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "sets", "4" },
                            { "each_leg", true }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Calf Raises")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 30,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "4" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Glute Bridge")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 25,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "4" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("b1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                Name = "Back & Posture Fix",
                Description = "Strengthen your back and improve posture with targeted exercises",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Superman")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 15,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "3" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Dumbbell Rows")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 12,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "4" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Plank")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 1,
                        Duration = 45,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "3" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("c2c3d4e5-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),
                Name = "Beginner Full Body",
                Description = "Perfect starting workout for fitness newcomers targeting all major muscle groups",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Standing Pose")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 1,
                        Duration = 30,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "purpose", "warmup" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Air Squat")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 10,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "sets", "2" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Pushup")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 5,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "sets", "2" },
                            { "modification", "knee pushups allowed" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Glute Bridge")?.Id ?? motions.First().Id,
                        Speed = 1,
                        Repetitions = 15,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "low" },
                            { "sets", "2" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Laying On The Floor")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 1,
                        Duration = 60,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "very low" },
                            { "purpose", "cooldown" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("d3c4d5e6-7f8a-9b0c-1d2e-3f4a5b6c7d8e"),
                Name = "15-Minute Express",
                Description = "Quick but effective full body workout when you're short on time",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Jumping Jacks")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 30,
                        Duration = 60,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "purpose", "warmup" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Burpees")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 10,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "sets", "3" },
                            { "rest", "30 seconds" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Plank")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 1,
                        Duration = 45,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "2" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("e4d5e6f7-8a9b-0c1d-2e3f-4a5b6c7d8e9f"),
                Name = "Core Stability Challenge",
                Description = "Advanced core workout focusing on stability and control",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Dead Bug")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 15,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "4" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Plank")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 1,
                        Duration = 90,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "sets", "3" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Superman")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 20,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "4" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("f5e6f7a8-9b0c-1d2e-3f4a-5b6c7d8e9f0a"),
                Name = "Cardio & Core Combo",
                Description = "Blend of cardiovascular and core exercises for overall fitness",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "High Knees")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 40,
                        Duration = 60,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "sets", "3" },
                            { "rest", "20 seconds" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Mountain Climbers")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 25,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "sets", "3" },
                            { "rest", "20 seconds" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Bicycle Crunches")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 25,
                        Duration = 30,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "3" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("a6f7a8b9-0b1c-2d3e-4f5a-6b7c8d9e0f1a"),
                Name = "Glute Activation",
                Description = "Targeted glute workout for strength, shape, and injury prevention",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Glute Bridge")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 25,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "4" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Lunges")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 15,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "4" },
                            { "each_leg", true }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Air Squat")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 20,
                        Duration = 60,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "4" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("b7a8b9c0-1d2e-3f4a-5b6c-7d8e9f0a1b2c"),
                Name = "Evening Wind Down",
                Description = "Gentle stretching and relaxation exercises to end your day",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Sitting On The Floor")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 1,
                        Duration = 120,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "very low" },
                            { "purpose", "stretching" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Laying On The Floor")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 1,
                        Duration = 180,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "very low" },
                            { "purpose", "relaxation" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Glute Bridge")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 10,
                        Duration = 60,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "very low" },
                            { "purpose", "gentle activation" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("c8b9c0d1-2e3f-4a5b-6c7d-8e9f0a1b2c3d"),
                Name = "Athletic Performance",
                Description = "Sport-focused workout to improve power and agility",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Burpees")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 12,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "maximum" },
                            { "sets", "4" },
                            { "rest", "60 seconds" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Mountain Climbers")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 30,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "sets", "4" },
                            { "rest", "45 seconds" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "High Knees")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 50,
                        Duration = 60,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "high" },
                            { "sets", "4" },
                            { "rest", "45 seconds" }
                        }
                    }
                }
            },
            new Workout
            {
                Id = Guid.Parse("d9c0d1e2-3f4a-5b6c-7d8e-9f0a1b2c3d4e"),
                Name = "Bodyweight Only",
                Description = "Complete workout using just your bodyweight - no equipment needed",
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Pushup")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 15,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "4" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Air Squat")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 25,
                        Duration = 60,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "4" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Plank")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 1,
                        Duration = 60,
                        ExerciseType = ExerciseType.Duration,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "3" }
                        }
                    },
                    new Exercise
                    {
                        MotionId = motions.FirstOrDefault(m => m.Name == "Lunges")?.Id ?? motions.First().Id,
                        Speed = 100,
                        Repetitions = 20,
                        Duration = 45,
                        ExerciseType = ExerciseType.Repetition,
                        CustomFields = new Dictionary<string, object>
                        {
                            { "intensity", "medium" },
                            { "sets", "3" },
                            { "each_leg", true }
                        }
                    }
                }
            }
        };
    }
}