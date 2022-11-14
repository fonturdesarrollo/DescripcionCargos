using DescripcionCargos.Core;
using Microsoft.AspNetCore.HttpOverrides;
using Rotativa.AspNetCore;
using static DescripcionCargos.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();

// Manage Sessions
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IFichaDescriptivaCargo, FichaDescriptivaCargo>();
builder.Services.AddTransient<IEmpleado, Empleados>();

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor |
    ForwardedHeaders.XForwardedProto
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");
app.MapControllerRoute(
    name: "result",
    pattern: "{controller=Result}/{action=Index}/{id?}");
app.MapControllerRoute(
	name: "result",
	pattern: "{controller=Catalogo}/{action=Index}/{id?}");

app.Run();
