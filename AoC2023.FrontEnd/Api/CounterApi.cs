
using AoC2023.FrontEnd.Components.Hx;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AoC2023.FrontEnd.Api;

public class CounterApi(IServiceProvider sp, ILoggerFactory lf) : IApi, ICounterApi
{
    // for dynamicall calling AddToApp
    // public CounterApi() : this(null, null) { }
    private static int Count = 0;
    public void AddToApp(WebApplication app)
    {
        app.MapGet("/increment", () => RenderRazorComponentResult(GetCounterComponent()));
    }

    public async Task<string> RenderHtml<T>(Component<T> component)
    where T : Microsoft.AspNetCore.Components.IComponent
    {
        IServiceScope sps = sp.CreateScope();
        await using var htmlRenderer = new HtmlRenderer(sps.ServiceProvider, lf);
        var html = await htmlRenderer.Dispatcher.InvokeAsync(async () =>
        {
            var output = await htmlRenderer.RenderComponentAsync<T>(ParameterView.FromDictionary(component.p));

            return output.ToHtmlString();
        });

        return html;
    }

    public record Component<T>(Parameters p);

    public Component<HxCounter> GetCounterComponent()
    {
        var parameters = new Parameters() {
                { nameof(HxCounter.Count), Count++ }
            };

        return new Component<HxCounter>(parameters);
    }

    public RazorComponentResult<T> RenderRazorComponentResult<T>(Component<T> component)
    where T : Microsoft.AspNetCore.Components.IComponent
     => new RazorComponentResult<T>(component.p);

    public async Task<string> GetCounter2() => await RenderHtml(GetCounterComponent());

    public RazorComponentResult<HxCounter> GetCounter()
    {
        var parameters = new Parameters() {
                { nameof(HxCounter.Count), Count++ }
            };


        return new RazorComponentResult<HxCounter>(parameters);
    }
}