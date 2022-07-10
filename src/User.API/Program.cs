using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using User.API.Database;

var builder = WebApplication.CreateBuilder(args);
string connectString = builder.Configuration.GetConnectionString("SmartCloud");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbcontext>(options => {
    options.UseMySql(connectString, ServerVersion.AutoDetect(connectString));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
