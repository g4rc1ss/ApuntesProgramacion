using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebAPI.Backend.Business;
using WebAPI.Backend.Data;
using WebAPI.Backend.Data.Database.Identity;

namespace WebAPI.Frontend.Api {
    public class Startup {
        public Startup(IConfiguration configuration, IHostEnvironment environment) {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            _ = services.AddControllers();

            _ = services.AddSwaggerGen(swagger => {
                swagger.SwaggerDoc("v1", new OpenApiInfo {
                    Title = nameof(WebAPI),
                    Version = "v1"
                });
            });

            _ = services.AddIdentity<User, Role>(options => {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
            }).AddDefaultTokenProviders()
              .AddSignInManager<SignInManager<User>>()
              .AddRoles<Role>()
              .AddEntityFrameworkStores<WebApiPruebaContext>();

            _ = services.AddDbContext<WebApiPruebaContext>(options => {
                _ = options.UseSqlServer(Configuration.GetConnectionString(nameof(WebApiPruebaContext)));
            });
            _ = services.AddWebApiBackendBusiness();
            _ = services.AddWebApiBackendData();

            _ = services.ConfigureApplicationCookie(opts => {
                opts.LoginPath = "/Login";
                opts.AccessDeniedPath = "";
                opts.LogoutPath = "";
                opts.SlidingExpiration = true;
                opts.ExpireTimeSpan = TimeSpan.FromHours(5);
                opts.Cookie.Name = "WebApiPruebaIdentityCookie";
                opts.Cookie.SecurePolicy = Environment.IsDevelopment() ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.Always;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                _ = app.UseDeveloperExceptionPage();
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI(swagger => swagger.SwaggerEndpoint("/swagger/v1/swagger.json", $"{nameof(WebAPI)} v1"));
            }

            _ = app.UseHttpsRedirection();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
