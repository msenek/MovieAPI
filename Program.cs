using MovieAPI.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// DbContext
var dbPath = Path.Combine(builder.Environment.ContentRootPath, "app.db");

builder.Services.AddDbContext<MovieContex>(options =>
    options.UseSqlite($"Data Source={dbPath}")
);


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();
