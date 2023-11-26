using AoC2023.FrontEnd.Components.Hx;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AoC2023.FrontEnd.Api;
public interface ICounterApi {
    public RazorComponentResult<HxCounter> GetCounter();
    public Task<string> GetCounter2();

};
