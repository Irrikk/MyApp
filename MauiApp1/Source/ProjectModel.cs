using System.Text.Json.Serialization;

namespace MauiApp1.Models;

public class ProjectModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
    
    [JsonPropertyName("lastModified")]
    public DateTime LastModified { get; set; } = DateTime.Now;

    public override string ToString() => $"{Name} (Last modified: {LastModified:g})"; // для отладки

    public bool IsValid() => !string.IsNullOrWhiteSpace(Name); // метод для проверки валидности проекта
}