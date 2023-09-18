using Microsoft.EntityFrameworkCore;
using ProjectCylcone.API.Context;
using ProjectCylcone.API.Repository.Classes;
using ProjectCylcone.API.Repository.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//configure database
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection")!; 

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
