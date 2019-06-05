using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using UserAPI.Infraestructure;
using UserAPI.Map;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using UserAPI.Services;
using UserAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace UserAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddDbContext<UsersDBContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersBBDD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType<UsersService>().As<IUsersService>();
            builder.RegisterType<UsersDomain>().As<IUsersDomain>();
            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "swagger_root",
                    template: "swagger/ui/index");

                routes.MapRoute(
                                name: "default",
                                template: "{controller=App}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                        name: "spa-fallback",
                        defaults: new { controller = "Users", action = "GetAll" });
            });
        }     
    }
}
