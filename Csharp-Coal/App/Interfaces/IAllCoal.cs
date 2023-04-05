using Csharp_Coal.App.Models;

namespace Csharp_Coal.App.Interfaces;

public interface IAllCoal
{
    IEnumerable<CategorySize> GetCoals { get;  }
    
}