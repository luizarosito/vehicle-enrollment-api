using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vehicle_enrollment.Db;
using vehicle_enrollment.Domain.Interface;
using vehicle_enrollment.Domain.Service;
using vehicle_enrollment.Models;
using vehicle_enrollment_api.Entities;
using Microsoft.OpenApi.Models;
using vehicle_enrollment_api.Domain.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContextConfig>(options => {
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

var app = builder.Build();

app.MapGet("/", () => Results.Json( new Home()));

app.MapPost("/login", ([FromBody] LoginModel loginModel, IAdminService adminService) =>{
    if(adminService.Login(loginModel) != null)
        return Results.Ok("Sucess Login");
    else 
    return Results.Unauthorized(); 
});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

