using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApiExample.Business.Action;
using WebApiExample.Business.Manager;
using WebApiExample.Database;
using WebApiExample.Database.Queries;

namespace WebApiExample {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiExample", Version = "v1" });
            });

            // Cuando se van a realizar solicitudes sobre el mismo origen, por ejemplo, ejecutando una app Blazor se requiere permitirlo mediante una policita de configuracion
            services.AddCors(option => {
                option.AddPolicy("open", builder => builder.AllowAnyOrigin().AllowAnyHeader());
            });

            services.AddDataProtection();
            services.AddSingleton<IDapperConfig, DapperConfig>();
            services.AddScoped<IActionUsers, ActionUsers>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUsersDatabase, UsersDatabase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiExample v1"));
                app.UseCors("open");
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
