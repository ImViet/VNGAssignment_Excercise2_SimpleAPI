using Microsoft.AspNetCore.Identity;
using Serilog;
using VNGAssignment.Business;
using VNGAssignment.Contracts;
using VNGAssignment.DataAccessor;
using VNGAssignment.DataAccessor.Data;
using VNGAssignment.DataAccessor.Data.Seeds;
using VNGAssignment.WebAPI.Extensions;
using VNGAssignment.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Register service layer
builder.Services.AddHttpContextAccessor();
builder.Services.AddDataAccessorLayer();
builder.Services.AddBusinessLayer();
builder.Services.AddContractsLayer();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.ConfigureAppConfiguration((context, config) => {
    var env = context.HostingEnvironment;
    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
}).UseSerilog(Serilogger.Configure);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<AppDbContext>();
        await DefaultSeeds.SeedAsync(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseMiddleware<ErrorHandler>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
