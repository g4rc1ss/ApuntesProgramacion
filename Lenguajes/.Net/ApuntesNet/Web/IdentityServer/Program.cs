using IdentityServer.Database;
using IdentityServer.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContextPool<IdentityContext>(contextBuilder =>
{
    contextBuilder.UseSqlServer(builder.Configuration.GetConnectionString(nameof(IdentityContext)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var contexto = app.Services.GetRequiredService<IdentityContext>();
await contexto.Database.EnsureDeletedAsync();
await contexto.Database.MigrateAsync();

var roleManager = app.Services.GetRequiredService<RoleManager<Role>>();
await roleManager.CreateAsync(new Role
{
    Name = "Usuario"
});

var userManager = app.Services.GetRequiredService<UserManager<User>>();
var usuario = new User
{
    UserName = "usuario",
    Email = "hola@hola.es",
    PhoneNumber = "123456789"
};
await userManager.CreateAsync(usuario, "ContraseñaPrueba");
await userManager.AddToRoleAsync(usuario, "Usuario");



await app.RunAsync();
