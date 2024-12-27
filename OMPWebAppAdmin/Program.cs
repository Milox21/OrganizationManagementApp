using OMPWebAppAdmin.Components;
using OMPWebAppAdmin.Services;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7070/")
});
// Register Radzen services
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<ThemeService>();

builder.Services.AddScoped(typeof(ApiConnectionService<>));
builder.Services.AddScoped<AuthorizationService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts(); // HTTPS dla produkcji
}

app.UseHttpsRedirection();

app.UseStaticFiles(); // Obs³uga plików statycznych (np. CSS, JS)
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // Obs³uga interaktywnego renderowania

app.Run();
