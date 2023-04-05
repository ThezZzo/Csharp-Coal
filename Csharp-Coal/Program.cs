using Csharp_Coal.App.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

//Подключение к БД
builder.Services.AddDbContext<CoalDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.MapGet("/",  async(CoalDbContext db) => db.CategorySizes
    .Include(с =>с.Category)
    .Include(s =>s.SizeCoal)
    .ToList());


app.MapRazorPages();  
app.Run();