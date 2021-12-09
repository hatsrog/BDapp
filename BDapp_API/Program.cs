using Microsoft.EntityFrameworkCore;
using BDapp_API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StockContext>(opt =>
    opt.UseInMemoryDatabase("stockList"));
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
