using Fluxor;
using FluxorMemoryLeak;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddFluxor(GetFluxorOptionsByHostEnvironment(builder));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();



Action<Fluxor.DependencyInjection.FluxorOptions> GetFluxorOptionsByHostEnvironment(WebAssemblyHostBuilder builder)
{
    return options =>
    {
        options.ScanAssemblies(typeof(AssetState).Assembly);
    };

}
