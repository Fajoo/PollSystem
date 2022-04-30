using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Desktop.Models;

public class Category
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("img")]
    public string? Img { get; set; }
}


public class CategoryList
{
    public Category[] Categories { get; set; }
}

