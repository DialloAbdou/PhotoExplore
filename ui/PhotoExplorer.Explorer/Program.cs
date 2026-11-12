using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PhotoExplorer.Shared.Services;
using PhotoExplorer.Explorer;
using PhotoExplorer.Explorer.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IPhotoService, PhotoServiceExplorer>(_ => new PhotoServiceExplorer(new HttpClient
{
    BaseAddress = new Uri("http://localhost:5205")
}));




await builder.Build().RunAsync();
