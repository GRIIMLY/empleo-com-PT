using EmpleadoComFrontend.Config;
using EmpleadoComFrontend.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient(); 
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<DemandanteService>();
builder.Services.AddScoped<HabilidadService>();
builder.Services.AddScoped<HabilidadUsuarioTrabajoService>();
builder.Services.AddScoped<DescripcionesTrabajoService>();


builder.Services.Configure<Settings>(builder.Configuration.GetSection("urlService"));
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de expiración de la sesión
    options.Cookie.HttpOnly = true; // Solo accesible a través de HTTP
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession(); // Middleware para gestionar sesiones

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Account}/{action=Index}/{id?}"); 
});
app.Run();
