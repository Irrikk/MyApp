using System.Text.Json;
using Microsoft.Maui.Storage;
using MauiApp1.Models;

namespace MauiApp1.Services;

public static class ProjectStorage
{
    private const string ProjectsKey = "SavedProjects";
     public static List<ProjectModel> LoadProjects()
    {
        var json = Preferences.Default.Get(ProjectsKey, string.Empty);
        return string.IsNullOrWhiteSpace(json) 
            ? new List<ProjectModel>() 
            : JsonSerializer.Deserialize<List<ProjectModel>>(json) ?? new();
    }

    public static void SaveProject(ProjectModel project)
    {
        var projects = LoadProjects();
        var existing = projects.FirstOrDefault(p => p.Name == project.Name);
        
        if (existing != null)
        {
            existing.Content = project.Content;
        }
        else
        {
            projects.Add(project);
        }
        
        SaveAllProjects(projects);
    }

    public static void SaveAllProjects(List<ProjectModel> projects)
    {
        var json = JsonSerializer.Serialize(projects);
        Preferences.Default.Set(ProjectsKey, json);
    }

    public static void ClearAllProjects()
    {
        Preferences.Default.Remove(ProjectsKey);
    }
}