namespace Drugsearch.Models;
public class Drug
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }
    public string? Warnings { get; set; }
    public string? CommonUse { get; set; }
    public string? Ingredients { get; set; }
    public string? Images { get; set; }
    public string? Directions { get; set; }
    
}