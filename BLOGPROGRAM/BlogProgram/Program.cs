using BlogProgram.Application;
using BlogProgram.Application.Implementations;
using BlogProgram.Application.Interfaces;
using BlogProgram.Infrastructure.Data;
using BlogProgram.Infrastructure.Implementation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AddDbContext
//builder.Services.AddDbContext<DataBaseContext>(Options =>
//    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<DataBaseContext>(options =>
             options.UseSqlite("Data Source = DATABASE.Db"));


// add AutoMapper
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

// Add Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
//builder.Services.AddSingleton(Log.Logger);
builder.Services.AddMemoryCache();

//Log.Logger.Information("Starting application");


var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
