using AoC2023.FrontEnd.Components.Hx;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AoC2023.FrontEnd.Api;

public static class CounterApiSimple
{
    public static void AddToApp(WebApplication app)
    {
        app.MapGet("/increment2", (ICounterService counterService) =>
        {
            var parameters = new Parameters() {
                { nameof(HxCounter.Count), ++counterService.Count }
            };

            return new RazorComponentResult<HxCounter>(parameters);
        });

    }
}