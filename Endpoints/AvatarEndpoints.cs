using MotionRepoServer.Models;
using MotionRepoServer.Services;

namespace MotionRepoServer.Endpoints;

public static class AvatarEndpoints
{
    public static void MapAvatarEndpoints(this WebApplication app)
    {
        // GET /avatars - Get all avatars with filtering and pagination
        app.MapGet("/avatars", (AvatarService avatarService, int? offset, int? limit, string? tags, string? search) =>
        {
            PagedResponse<Avatar>? response = avatarService.GetAvatars(offset, limit, tags, search);
            return Results.Ok(response);
        })
        .WithName("GetAvatars");

        // GET /avatars/:id - Get a single avatar
        app.MapGet("/avatars/{id:guid}", (AvatarService avatarService, Guid id) =>
        {
            var avatar = avatarService.GetAvatarById(id);
            return avatar is not null ? Results.Ok(avatar) : Results.NotFound();
        })
        .WithName("GetAvatar");

        // POST /avatars - Create a new avatar
        app.MapPost("/avatars", (AvatarService avatarService, CreateAvatarRequest request) =>
        {
            var avatar = avatarService.CreateAvatar(request);
            return Results.Created($"/avatars/{avatar.Id}", avatar);
        })
        .RequireAuthorization()
        .WithName("CreateAvatar");

        // PUT /avatars/:id - Update an avatar
        app.MapPut("/avatars/{id:guid}", (AvatarService avatarService, Guid id, UpdateAvatarRequest request) =>
        {
            var updatedAvatar = avatarService.UpdateAvatar(id, request);
            return updatedAvatar is not null ? Results.Ok(updatedAvatar) : Results.NotFound();
        })
        .RequireAuthorization()
        .WithName("UpdateAvatar");

        // DELETE /avatars/:id - Delete an avatar
        app.MapDelete("/avatars/{id:guid}", (AvatarService avatarService, Guid id) =>
        {
            var deleted = avatarService.DeleteAvatar(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        })
        .RequireAuthorization()
        .WithName("DeleteAvatar");
    }
}