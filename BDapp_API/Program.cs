using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BDapp_API.DbModels;
using BDapp_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1"
    });
});
builder.Services.AddDbContext<BdappContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BDappDatabase"));
});
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.Run();
