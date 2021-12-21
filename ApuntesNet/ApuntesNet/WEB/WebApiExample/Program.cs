using Microsoft.OpenApi.Models;
using WebApiExample.Business.Action;
using WebApiExample.Business.Manager;
using WebApiExample.Database;
using WebApiExample.Database.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiExample", Version = "v1" });
});

// Cuando se van a realizar solicitudes sobre el mismo origen, por ejemplo, ejecutando una app Blazor se requiere permitirlo mediante una policita de configuracion
builder.Services.AddCors(option => {
    option.AddPolicy("open", builder => builder.AllowAnyOrigin().AllowAnyHeader());
});

builder.Services.AddDataProtection();
builder.Services.AddSingleton<IDapperConfig, DapperConfig>();
builder.Services.AddScoped<IActionUsers, ActionUsers>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUsersDatabase, UsersDatabase>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiExample v1"));
    app.UseCors("open");
} else {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

await app.RunAsync();
