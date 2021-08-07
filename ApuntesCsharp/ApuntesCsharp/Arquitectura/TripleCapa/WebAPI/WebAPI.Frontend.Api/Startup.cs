using System;
using DataAccessLayer;
using DataAccessLayer.Database.Identity;
using InmobiliariaEguzkimendi.DataAccessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddControllers();

            services.AddIdentity<User, Role>(options => {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
            }).AddDefaultTokenProviders()
              .AddSignInManager<SignInManager<User>>()
              .AddRoles<Role>()
              .AddEntityFrameworkStores<WebApiPruebaContext>();

            services.AddDbContext<WebApiPruebaContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString(nameof(WebApiPruebaContext)));
            });
            services.AddEguzkimendiCore();
            services.AddEguzkimendiDAL();

            services.ConfigureApplicationCookie(opts => {
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
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
