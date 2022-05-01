using CleanArchitecture.Domain.OptionsConfig;
using CleanArchitecture.Ejemplo.RazorPages.Extensions;
using CleanArchitecture.Infraestructure.DataEntityFramework.Contexts;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Host.AddLoggerConfiguration(builder.Configuration.GetConnectionString(nameof(EjemploContext)));

// Add services to the container.
builder.Services.Configure<InfraestructureConfiguration>(builder.Configuration.GetSection(nameof(InfraestructureConfiguration)));
builder.Services.AddAppConfiguration(builder.Configuration);
builder.Services.AddRedisCache();
builder.Services.ConfigureDataProtectionProvider(builder.Configuration);
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(Program));
var razorPages = builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    razorPages.AddRazorRuntimeCompilation();
}

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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
