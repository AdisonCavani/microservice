using System.ComponentModel.DataAnnotations;

namespace CommandService.Database.Entities;

public class Command
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string HowTo { get; set; } = default!;

    [Required]
    public string CommandLine { get; set; } = default!;
    
    [Required]
    public int PlatformId { get; set; }
    
    // TODO: nullable property?
    public Platform Platform { get; set; }
}