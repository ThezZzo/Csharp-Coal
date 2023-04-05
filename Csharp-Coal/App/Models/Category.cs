using System.ComponentModel.DataAnnotations;

namespace Csharp_Coal.App.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int Carbon { get; set; }

    public int Volatiles { get; set; } 
    
    public string Heat { get; set; }
    
}