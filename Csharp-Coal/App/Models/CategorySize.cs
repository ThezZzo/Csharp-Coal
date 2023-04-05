using System.ComponentModel.DataAnnotations;

namespace Csharp_Coal.App.Models;

public class CategorySize
{

    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public int SizeCoalId { get; set; }
    
    public SizeCoal SizeCoal { get; set; }
    
    
    
}