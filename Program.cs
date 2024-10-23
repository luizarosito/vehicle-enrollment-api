using vehicle_enrollment.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginModel loginDTO) =>{
    if(loginDTO.Email == "adm@teste.com" && loginDTO.Password == "123")
        return Results.Ok("Sucess Login");
    else 
    return Results.Unauthorized(); 
});

app.Run();

