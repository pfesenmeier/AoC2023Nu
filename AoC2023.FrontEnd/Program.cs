using AoC2023.FrontEnd.Api;
using AoC2023.FrontEnd.Components;
using AoC2023.FrontEnd.Components.Hx;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<ICounterService, CounterService>();
builder.Services.AddSingleton<ICounterApi, CounterApi>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// var apis = AppDomain.CurrentDomain.GetAssemblies()
//   .SelectMany(assembly => assembly.GetTypes())
//   .Where(type => typeof(IApi).IsAssignableFrom(type) && type.IsClass);
// 
// foreach (var api in apis)
// {
    // var instance = Activator.CreateInstance(api) as IApi;
// 
    // instance?.AddToApp(app);
// }
// 
IServiceCollection services = new ServiceCollection();
services.AddLogging();
IServiceProvider serviceProvider = services.BuildServiceProvider();
ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

new CounterApi(serviceProvider,loggerFactory).AddToApp(app);

CounterApiSimple.AddToApp(app);

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.MapGet("/tab", (string tab) => Database.TabDictionary.GetValueOrDefault(tab) ?? "no data found");

app.Run();
