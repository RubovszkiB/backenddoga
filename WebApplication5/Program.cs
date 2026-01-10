using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication5.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

string connectionString = "server=localhost;database=cinemadb;user=root;password=";
builder.Services.AddDbContext<CinemaDbContext>(options =>
    options.UseMySQL(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();