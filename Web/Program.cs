using AoC2023.FrontEnd.Components.Pages;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
