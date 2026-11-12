using PhotoExplorer.Shared.Model;
using PhotoExplorer.Shared.Services;

using PhotoExplorer.Manager.Components;
using PhotoExplorer.Manager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<IPhotoService, PhotoServiceManager>();
//builder.Services.AddHttpClient();

builder.Services.AddHttpClient("Photo", client =>
{
    client.BaseAddress = new Uri("http://localhost:5205/");
});

//builder.Services.AddScoped(sp =>
//    sp.GetRequiredService<IHttpClientFactory>().CreateClient());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
