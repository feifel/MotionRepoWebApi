using MotionRepoServer.Models;
using MotionRepoServer.Services;

namespace MotionRepoServer.Endpoints;

public static class MotionEndpoints
{
    public static void MapMotionEndpoints(this WebApplication app)
    {
        // GET /motions - Get all motions with filtering and pagination
        app.MapGet("/motions", (MotionService motionService, int? offset, int? limit, string? tags, string? search) =>
        {
            var result = motionService.GetMotions(offset, limit, tags, search);
            return Results.Ok(result);
        })
        .WithName("GetMotions");

        // GET /motions/:id - Get a single motion
        app.MapGet("/motions/{id:guid}", (MotionService motionService, Guid id) =>
        {
            var motion = motionService.GetMotionById(id);
            return motion is not null ? Results.Ok(motion) : Results.NotFound();
        })
        .WithName("GetMotion");

        // GET /motions/tags - Get all unique tags from motions
        app.MapGet("/motions/tags", (MotionService motionService) =>
        {
            var tags = motionService.GetMotionTags();
            return Results.Ok(tags);
        })
        .WithName("GetMotionTags");

        // POST /motions - Create a new motion
        app.MapPost("/motions", (MotionService motionService, CreateMotionRequest request) =>
        {
            var motion = motionService.CreateMotion(request);
            return Results.Created($"/motions/{motion.Id}", motion);
        })
        .RequireAuthorization()
        .WithName("CreateMotion");

        // PUT /motions/:id - Update a motion
        app.MapPut("/motions/{id:guid}", (MotionService motionService, Guid id, UpdateMotionRequest request) =>
        {
            var updatedMotion = motionService.UpdateMotion(id, request);
            return updatedMotion is not null ? Results.Ok(updatedMotion) : Results.NotFound();
        })
        .RequireAuthorization()
        .WithName("UpdateMotion");

        // DELETE /motions/:id - Delete a motion
        app.MapDelete("/motions/{id:guid}", (MotionService motionService, Guid id) =>
        {
            var deleted = motionService.DeleteMotion(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        })
        .RequireAuthorization()
        .WithName("DeleteMotion");
    }
}