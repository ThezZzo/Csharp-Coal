using System.ComponentModel.DataAnnotations;

namespace Csharp_Coal.App.Models;

public class SizeCoal
{
    [Key]
    public int Id { get; set; } 
    public string Name { get; set; } = null!;

    public string Size { get; set; } = null!;
    
}