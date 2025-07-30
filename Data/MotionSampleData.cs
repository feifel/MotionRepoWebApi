using MotionRepoServer.Models;

namespace MotionRepoServer.Data;

public static class MotionSampleData
{
    public static List<Motion> GetSampleMotions()
    {
        return new List<Motion>
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
            },
            new Motion
            {
                Id = Guid.Parse("8f7e3c2a-9b4f-4e8d-9c7b-2f1e5a8c3d7f"),
                Name = "Plank",
                Description = "Core strengthening isometric hold",
                File = "Plank.glb",
                FileType = "GLB",
                Screenshot = "plank_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Core", "Shoulders" },
                MuscleGroups = new[] { "Abs", "Obliques", "Shoulders" },
                Categories = new[] { "Strength", "Core", "Isometric" },
                PrimaryJoints = new[] { "Shoulder", "Elbow", "Spine" },
                Labels = new[] { "Core", "Plank", "Isometric" }
            },
            new Motion
            {
                Id = Guid.Parse("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                Name = "Lunges",
                Description = "Single leg strength and balance exercise",
                File = "Lunges.glb",
                FileType = "GLB",
                Screenshot = "lunges_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Legs", "Glutes" },
                MuscleGroups = new[] { "Quads", "Glutes", "Hamstrings" },
                Categories = new[] { "Strength", "LowerBody", "Balance" },
                PrimaryJoints = new[] { "Knee", "Hip", "Ankle" },
                Labels = new[] { "Lunge", "Legs", "Balance" }
            },
            new Motion
            {
                Id = Guid.Parse("b2c3d4e5-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),
                Name = "Mountain Climbers",
                Description = "High intensity cardio and core exercise",
                File = "MountainClimbers.glb",
                FileType = "GLB",
                Screenshot = "mountain_climbers_screenshot.jpg",
                Level = 3,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Core", "Legs", "Shoulders" },
                MuscleGroups = new[] { "Abs", "Quads", "Shoulders" },
                Categories = new[] { "Cardio", "Core", "HIIT" },
                PrimaryJoints = new[] { "Shoulder", "Hip", "Knee" },
                Labels = new[] { "Cardio", "HIIT", "Core" }
            },
            new Motion
            {
                Id = Guid.Parse("c3d4e5f6-7a8b-9c0d-1e2f-3a4b5c6d7e8f"),
                Name = "Burpees",
                Description = "Full body high intensity exercise",
                File = "Burpees.glb",
                FileType = "GLB",
                Screenshot = "burpees_screenshot.jpg",
                Level = 4,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "FullBody" },
                MuscleGroups = new[] { "Chest", "Quads", "Core", "Shoulders" },
                Categories = new[] { "Cardio", "HIIT", "FullBody" },
                PrimaryJoints = new[] { "Shoulder", "Elbow", "Hip", "Knee" },
                Labels = new[] { "Burpees", "HIIT", "FullBody" }
            },
            new Motion
            {
                Id = Guid.Parse("d4e5f6a7-8b9c-0d1e-2f3a-4b5c6d7e8f9a"),
                Name = "Dumbbell Rows",
                Description = "Back strengthening with dumbbells",
                File = "DumbbellRows.glb",
                FileType = "GLB",
                Screenshot = "dumbbell_rows_screenshot.jpg",
                Level = 3,
                Equipment = new[] { "Dumbbells" },
                BodyParts = new[] { "Back", "Arms" },
                MuscleGroups = new[] { "Lats", "Rhomboids", "Biceps" },
                Categories = new[] { "Strength", "UpperBody", "Back" },
                PrimaryJoints = new[] { "Shoulder", "Elbow" },
                Labels = new[] { "Rows", "Back", "Dumbbells" }
            },
            new Motion
            {
                Id = Guid.Parse("e5f6a7b8-9c0d-1e2f-3a4b-5c6d7e8f9a0b"),
                Name = "Jumping Jacks",
                Description = "Cardiovascular warm-up exercise",
                File = "JumpingJacks.glb",
                FileType = "GLB",
                Screenshot = "jumping_jacks_screenshot.jpg",
                Level = 1,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "FullBody" },
                MuscleGroups = new[] { "Calves", "Shoulders", "Core" },
                Categories = new[] { "Cardio", "WarmUp", "FullBody" },
                PrimaryJoints = new[] { "Shoulder", "Hip", "Knee", "Ankle" },
                Labels = new[] { "Cardio", "WarmUp", "Jumping" }
            },
            new Motion
            {
                Id = Guid.Parse("f6a7b8c9-0d1e-2f3a-4b5c-6d7e8f9a0b1c"),
                Name = "Dead Bug",
                Description = "Core stability and coordination exercise",
                File = "DeadBug.glb",
                FileType = "GLB",
                Screenshot = "dead_bug_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Core" },
                MuscleGroups = new[] { "Abs", "Obliques", "TransverseAbdominis" },
                Categories = new[] { "Strength", "Core", "Stability" },
                PrimaryJoints = new[] { "Hip", "Shoulder", "Spine" },
                Labels = new[] { "Core", "Stability", "Coordination" }
            },
            new Motion
            {
                Id = Guid.Parse("a7b8c9d0-1e2f-3a4b-5c6d-7e8f9a0b1c2d"),
                Name = "Glute Bridge",
                Description = "Glute and hamstring activation exercise",
                File = "GluteBridge.glb",
                FileType = "GLB",
                Screenshot = "glute_bridge_screenshot.jpg",
                Level = 1,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Glutes", "Core" },
                MuscleGroups = new[] { "Glutes", "Hamstrings", "Core" },
                Categories = new[] { "Strength", "LowerBody", "Activation" },
                PrimaryJoints = new[] { "Hip", "Spine", "Knee" },
                Labels = new[] { "Glutes", "Bridge", "Activation" }
            },
            new Motion
            {
                Id = Guid.Parse("b8c9d0e1-2f3a-4b5c-6d7e-8f9a0b1c2d3e"),
                Name = "Shoulder Press",
                Description = "Overhead pressing movement for shoulders",
                File = "ShoulderPress.glb",
                FileType = "GLB",
                Screenshot = "shoulder_press_screenshot.jpg",
                Level = 3,
                Equipment = new[] { "Dumbbells" },
                BodyParts = new[] { "Shoulders", "Arms" },
                MuscleGroups = new[] { "Deltoids", "Triceps", "UpperChest" },
                Categories = new[] { "Strength", "UpperBody", "Shoulders" },
                PrimaryJoints = new[] { "Shoulder", "Elbow" },
                Labels = new[] { "Press", "Shoulders", "Overhead" }
            },
            new Motion
            {
                Id = Guid.Parse("c9d0e1f2-3a4b-5c6d-7e8f-9a0b1c2d3e4f"),
                Name = "Bicycle Crunches",
                Description = "Rotational core exercise targeting obliques",
                File = "BicycleCrunches.glb",
                FileType = "GLB",
                Screenshot = "bicycle_crunches_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Core" },
                MuscleGroups = new[] { "Abs", "Obliques", "HipFlexors" },
                Categories = new[] { "Strength", "Core", "Rotation" },
                PrimaryJoints = new[] { "Spine", "Hip" },
                Labels = new[] { "Crunches", "Obliques", "Rotation" }
            },
            new Motion
            {
                Id = Guid.Parse("d0e1f2a3-4b5c-6d7e-8f9a-0b1c2d3e4f5a"),
                Name = "High Knees",
                Description = "Cardio exercise with high knee lifts",
                File = "HighKnees.glb",
                FileType = "GLB",
                Screenshot = "high_knees_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Legs", "Core" },
                MuscleGroups = new[] { "Quads", "HipFlexors", "Core" },
                Categories = new[] { "Cardio", "HIIT", "LowerBody" },
                PrimaryJoints = new[] { "Hip", "Knee", "Ankle" },
                Labels = new[] { "Cardio", "HighKnees", "Running" }
            },
            new Motion
            {
                Id = Guid.Parse("e1f2a3b4-5c6d-7e8f-9a0b-1c2d3e4f5a6b"),
                Name = "Russian Twists",
                Description = "Rotational core exercise with seated position",
                File = "RussianTwists.glb",
                FileType = "GLB",
                Screenshot = "russian_twists_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Core", "Shoulders" },
                MuscleGroups = new[] { "Obliques", "Abs", "Shoulders" },
                Categories = new[] { "Strength", "Core", "Rotation" },
                PrimaryJoints = new[] { "Spine", "Hip" },
                Labels = new[] { "Twists", "Obliques", "Seated" }
            },
            new Motion
            {
                Id = Guid.Parse("f2a3b4c5-6d7e-8f9a-0b1c-2d3e4f5a6b7c"),
                Name = "Wall Sit",
                Description = "Isometric leg strengthening against wall",
                File = "WallSit.glb",
                FileType = "GLB",
                Screenshot = "wall_sit_screenshot.jpg",
                Level = 2,
                Equipment = new[] { "Wall" },
                BodyParts = new[] { "Legs", "Glutes" },
                MuscleGroups = new[] { "Quads", "Glutes", "Calves" },
                Categories = new[] { "Strength", "LowerBody", "Isometric" },
                PrimaryJoints = new[] { "Knee", "Hip", "Ankle" },
                Labels = new[] { "WallSit", "Isometric", "Legs" }
            },
            new Motion
            {
                Id = Guid.Parse("a3b4c5d6-7e8f-9a0b-1c2d-3e4f5a6b7c8d"),
                Name = "Calf Raises",
                Description = "Calf muscle strengthening exercise",
                File = "CalfRaises.glb",
                FileType = "GLB",
                Screenshot = "calf_raises_screenshot.jpg",
                Level = 1,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Legs" },
                MuscleGroups = new[] { "Calves", "Ankles" },
                Categories = new[] { "Strength", "LowerBody", "Calves" },
                PrimaryJoints = new[] { "Ankle", "Knee" },
                Labels = new[] { "Calves", "Raises", "LowerLegs" }
            },
            new Motion
            {
                Id = Guid.Parse("b4c5d6e7-8f9a-0b1c-2d3e-4f5a6b7c8d9e"),
                Name = "Superman",
                Description = "Back extension exercise for posterior chain",
                File = "Superman.glb",
                FileType = "GLB",
                Screenshot = "superman_screenshot.jpg",
                Level = 1,
                Equipment = new[] { "NoEquipment" },
                BodyParts = new[] { "Back", "Glutes" },
                MuscleGroups = new[] { "LowerBack", "Glutes", "Hamstrings" },
                Categories = new[] { "Strength", "Back", "PosteriorChain" },
                PrimaryJoints = new[] { "Spine", "Hip", "Shoulder" },
                Labels = new[] { "BackExtension", "PosteriorChain", "Floor" }
            }
        };
    }
}