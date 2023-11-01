using AutoMapper;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using ProjectCylcone.API.Configs;
using ProjectCylcone.API.Context;
using ProjectCylcone.API.Repository.Classes;
using ProjectCylcone.API.Repository.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddOData(o => o.Select().Filter());

//configure database
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection")!; 

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

//configure repositories
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

//configure Auto Mapper
IMapper mapper = MapperConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
