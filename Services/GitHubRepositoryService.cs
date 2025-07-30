using System.Net.Http.Json;
using System.Text.Json;
using MotionRepoServer.Models;

namespace MotionRepoServer.Services;

public class GitHubRepositoryService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<GitHubRepositoryService> _logger;
    private readonly string _repositoryBaseUrl;
    private readonly string _repositoryOwner;
    private readonly string _repositoryName;
    private readonly string _branch;

    public GitHubRepositoryService(HttpClient httpClient, ILogger<GitHubRepositoryService> logger, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _logger = logger;
        
        var githubConfig = configuration.GetSection("GitHubRepository");
        _repositoryOwner = githubConfig["Owner"] ?? string.Empty;
        _repositoryName = githubConfig["Name"] ?? string.Empty;
        _branch = githubConfig["Branch"] ?? "main";
        
        if (string.IsNullOrEmpty(_repositoryOwner) || string.IsNullOrEmpty(_repositoryName))
        {
            _logger.LogWarning("GitHub repository configuration is missing. Using local data instead.");
            _repositoryBaseUrl = string.Empty;
        }
        else
        {
            _repositoryBaseUrl = $"https://raw.githubusercontent.com/{_repositoryOwner}/{_repositoryName}/{_branch}";
        }
    }

    public bool IsConfigured => !string.IsNullOrEmpty(_repositoryBaseUrl);

    public async Task<List<Avatar>> LoadAvatarsAsync()
    {
        if (!IsConfigured)
            return new List<Avatar>();

        try
        {
            var avatars = new List<Avatar>();
            var avatarsUrl = $"{_repositoryBaseUrl}/Avatars";
            
            // Get directory listing for avatars
            var avatarFolders = await GetDirectoryContentsAsync("Avatars");
            
            foreach (var folder in avatarFolders)
            {
                try
                {
                    var avatarJsonUrl = $"{_repositoryBaseUrl}/Avatars/{folder}/Avatar.json";
                    var avatarJson = await _httpClient.GetStringAsync(avatarJsonUrl);
                    var avatar = JsonSerializer.Deserialize<Avatar>(avatarJson, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    
                    if (avatar != null)
                    {
                        // Update the file path to include the full GitHub URL
                        var fileName = avatar.FileName;
                        var fileUrl = $"{_repositoryBaseUrl}/Avatars/{folder}/{fileName}";
                        avatars.Add(avatar with { FileName = fileUrl });
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to load avatar from folder {Folder}", folder);
                }
            }
            
            return avatars;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to load avatars from GitHub repository");
            return new List<Avatar>();
        }
    }

    public async Task<List<Motion>> LoadMotionsAsync()
    {
        if (!IsConfigured)
            return new List<Motion>();

        try
        {
            var motions = new List<Motion>();
            var motionsUrl = $"{_repositoryBaseUrl}/Motions";
            
            // Get directory listing for motions
            var motionFolders = await GetDirectoryContentsAsync("Motions");
            
            foreach (var folder in motionFolders)
            {
                try
                {
                    var motionJsonUrl = $"{_repositoryBaseUrl}/Motions/{folder}/Motion.json";
                    var motionJson = await _httpClient.GetStringAsync(motionJsonUrl);
                    var motion = JsonSerializer.Deserialize<Motion>(motionJson, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    
                    if (motion != null)
                    {
                        // Update the file path to include the full GitHub URL
                        var fileName = motion.File;
                        var fileUrl = $"{_repositoryBaseUrl}/Motions/{folder}/{fileName}";
                        motions.Add(motion with { File = fileUrl });
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to load motion from folder {Folder}", folder);
                }
            }
            
            return motions;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to load motions from GitHub repository");
            return new List<Motion>();
        }
    }

    public async Task<List<Workout>> LoadWorkoutsAsync()
    {
        if (!IsConfigured)
            return new List<Workout>();

        try
        {
            var workouts = new List<Workout>();
            var workoutsUrl = $"{_repositoryBaseUrl}/Workouts";
            
            // Get directory listing for workouts
            var workoutFolders = await GetDirectoryContentsAsync("Workouts");
            
            foreach (var folder in workoutFolders)
            {
                try
                {
                    var workoutJsonUrl = $"{_repositoryBaseUrl}/Workouts/{folder}/Workout.json";
                    var workoutJson = await _httpClient.GetStringAsync(workoutJsonUrl);
                    var workout = JsonSerializer.Deserialize<Workout>(workoutJson, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    
                    if (workout != null)
                    {
                        workouts.Add(workout);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to load workout from folder {Folder}", folder);
                }
            }
            
            return workouts;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to load workouts from GitHub repository");
            return new List<Workout>();
        }
    }

    private async Task<List<string>> GetDirectoryContentsAsync(string path)
    {
        try
        {
            // Use GitHub API to get directory contents
            var apiUrl = $"https://api.github.com/repos/{_repositoryOwner}/{_repositoryName}/contents/{path}?ref={_branch}";
            
            _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("MotionRepoWebApi");
            var response = await _httpClient.GetFromJsonAsync<GitHubContentItem[]>(apiUrl);
            
            return response?.Where(item => item.Type == "dir")
                           .Select(item => item.Name)
                           .ToList() ?? new List<string>();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to get directory contents for {Path}", path);
            return new List<string>();
        }
    }

    private record GitHubContentItem(string Name, string Type, string Path);
}