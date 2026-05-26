using Microsoft.EntityFrameworkCore;
using SalsaSimulator.Components;
using SalsaSimulator.Data;
using SalsaSimulator.Services;

var builder = WebApplication.CreateBuilder(args);

// ─────────────────────────────────────────────
// Servicios
// ─────────────────────────────────────────────

// Blazor Server
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Entity Framework + SQLite
builder.Services.AddDbContext<SalsaDbContext>(options =>
    options.UseSqlite("Data Source=salsa.db"));

builder.Services.AddScoped<SalsaCalculatorService>();
var app = builder.Build();

// ─────────────────────────────────────────────
// Aplicar migraciones automáticamente
// ─────────────────────────────────────────────
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SalsaDbContext>();
    db.Database.Migrate();
}

// ─────────────────────────────────────────────
// Middleware
// ─────────────────────────────────────────────
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// ─────────────────────────────────────────────
// Blazor
// ─────────────────────────────────────────────
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// ─────────────────────────────────────────────
// Endpoints de prueba DB
// ─────────────────────────────────────────────

// Ver todos los ajíes
app.MapGet("/ajies", async (SalsaDbContext db) =>
{
    return await db.Ajies.ToListAsync();
});

// Ver todos los builds
app.MapGet("/builds", async (SalsaDbContext db) =>
{
    return await db.Builds.ToListAsync();
});

app.UseStaticFiles();

// ─────────────────────────────────────────────
// Run app
// ─────────────────────────────────────────────
app.Run();