using LifecyclesDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddScoped<GeneratorScoped>();
builder.Services.AddSingleton<GeneratorSingleton>();
builder.Services.AddTransient<GeneratorTransient>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
