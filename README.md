# MotionRepoWebApi
REST API to access the [MotionRepo](https://github.com/feifel/MotionRepo) and the [MotionRepoContrib](https://github.com/feifel/MotionRepoContrib).

## Features
- Uses Auth0 for user Authentication.
- It provides CRUD operations for Workouts, Motions and Avatars.
- Read Operations do not need Authentication.
- **NEW**: Support for loading data from GitHub repositories with structured folders.

## GitHub Repository Integration

The API now supports loading avatars, motions, and workouts from a GitHub repository with the following structure:

```
├── Avatars/
│   ├── {avatar-id}/
│   │   ├── Avatar.json
│   │   └── {avatar-file}.glb
├── Motions/
│   ├── {motion-id}/
│   │   ├── Motion.json
│   │   └── {motion-file}.glb
└── Workouts/
    ├── {workout-id}/
    │   └── Workout.json
```

### Configuration

To configure a GitHub repository as your data source, update the `appsettings.json` file:

```json
{
  "GitHubRepository": {
    "Owner": "your-github-username",
    "Name": "your-repository-name",
    "Branch": "main"
  }
}
```

### JSON File Formats

#### Avatar.json
```json
{
  "id": "904d91dc-f6cf-4da6-a0cc-becdd51ac64f",
  "fileName": "MaleBot.glb",
  "name": "Male Bot",
  "description": "A male robot avatar",
  "gender": "Male",
  "categories": ["Robotics", "Technology"]
}
```

#### Motion.json
```json
{
  "id": "23b03363-3b5f-4a5e-804b-8d490f8e51e6",
  "name": "Air Squat",
  "description": "Basic air squat exercise",
  "file": "AirSquat.glb",
  "fileType": "GLB",
  "screenshot": "air_squat_screenshot.jpg",
  "level": 1,
  "equipment": ["NoEquipment"],
  "bodyParts": ["Legs", "Glutes"],
  "muscleGroups": ["Quads", "Hamstrings", "Glutes"],
  "categories": ["Strength", "LowerBody"],
  "primaryJoints": ["Knee", "Hip", "Ankle"],
  "labels": ["Squat", "Bodyweight", "Basic"]
}
```

#### Workout.json
```json
{
  "id": "3313c09e-2f1e-4b19-bab2-aed759966b6f",
  "name": "Morning Warm-up Routine",
  "description": "A quick 10-minute warm-up routine",
  "avatarId": "904d91dc-f6cf-4da6-a0cc-becdd51ac64f",
  "exercises": [
    {
      "motionId": "a2e4a2d5-bde4-4b3e-b376-ee3e1dbcbade",
      "speed": 1,
      "repetitions": 15,
      "duration": 60,
      "exerciseType": 1,
      "customFields": {
        "intensity": "low",
        "notes": "Focus on smooth, controlled movements"
      }
    }
  ]
}
```

### Fallback Behavior

If the GitHub repository is not configured or fails to load, the API will use built-in sample data as a fallback.

## how to build and run it
- Open the project in Visual Studio Code
- Open a terminal and run: dotnet run
- Open https://localhost:7031/swagger/index.html in your browser to access the Swagger UI and test it
- Except for the read operations you need to authenticate yourself by doing this:
  https://youtu.be/NEllH_jX9Dg?si=T40dqg0xuinJIlRj&t=104

## Environment Variables

You can also configure the GitHub repository using environment variables:
- `GITHUB_REPOSITORY_OWNER`
- `GITHUB_REPOSITORY_NAME`
- `GITHUB_REPOSITORY_BRANCH`