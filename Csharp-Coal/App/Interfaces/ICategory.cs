using System.ComponentModel.DataAnnotations;
using Csharp_Coal.App.Models;

namespace Csharp_Coal.App.Interfaces;

public interface ICategory
{
    IEnumerable<Category> AllCategories { get; }

}