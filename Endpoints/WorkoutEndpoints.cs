using MotionRepoServer.Models;
using MotionRepoServer.Services;

namespace MotionRepoServer.Endpoints;

public static class WorkoutEndpoints
{
    public static void MapWorkoutEndpoints(this WebApplication app)
    {
        // GET /workouts - Get all workouts with filtering and pagination
        app.MapGet("/workouts", (WorkoutService workoutService, int? offset, int? limit, string? search) =>
        {
            var result = workoutService.GetWorkouts(offset, limit, search);
            return Results.Ok(result);
        })
        .WithName("GetWorkouts");

        // GET /workouts/:id - Get a single workout
        app.MapGet("/workouts/{id:guid}", (WorkoutService workoutService, Guid id) =>
        {
            var workout = workoutService.GetWorkoutById(id);
            return workout is not null ? Results.Ok(workout) : Results.NotFound();
        })
        .WithName("GetWorkout");

        // POST /workouts - Create a new workout
        app.MapPost("/workouts", (WorkoutService workoutService, CreateWorkoutRequest request) =>
        {
            try
            {
                var workout = workoutService.CreateWorkout(request);
                return Results.Created($"/workouts/{workout.Id}", workout);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(ex.Message);
            }
        })
        .RequireAuthorization()
        .WithName("CreateWorkout");

        // PUT /workouts/:id - Update a workout
        app.MapPut("/workouts/{id:guid}", (WorkoutService workoutService, Guid id, UpdateWorkoutRequest request) =>
        {
            try
            {
                var updatedWorkout = workoutService.UpdateWorkout(id, request);
                return updatedWorkout is not null ? Results.Ok(updatedWorkout) : Results.NotFound();
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(ex.Message);
            }
        })
        .RequireAuthorization()
        .WithName("UpdateWorkout");

        // DELETE /workouts/:id - Delete a workout
        app.MapDelete("/workouts/{id:guid}", (WorkoutService workoutService, Guid id) =>
        {
            var deleted = workoutService.DeleteWorkout(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        })
        .RequireAuthorization()
        .WithName("DeleteWorkout");
    }
}