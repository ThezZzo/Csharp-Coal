using Csharp_Coal.App.Interfaces;
using Csharp_Coal.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Csharp_Coal.App.Controllers;

[ApiController]
[Route("controller")]
public class CoalController : Controller
{
    private readonly IAllCoal _allCoal;
    private readonly ICategory _allCoalCategory;

    public CoalController(IAllCoal iAllCoal, ICategory iCategory)
    {
        _allCoal = iAllCoal;
        _allCoalCategory = iCategory;
    }

    public ViewResult List()
    {
        var coal = _allCoal.GetCoals;
        return View(coal);
    }
}