using Context;
using Models;
using Models.Validators;

using FluentValidation;
using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Services;

namespace ODataTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation()
                .AddNewtonsoftJson();
            services.AddDbContext<ODataContext>();
            SetupValidators(services);
            SetupOData(services);
            SetupServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("Cache-Control", "no-store, no-cache");
                await next();
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(routeBuilder =>
            {
                routeBuilder.MapControllers();
                routeBuilder.MapODataRoute("api", "api", GetEdmModel());
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
            });
        }

        private void SetupServices(IServiceCollection services)
        {
            services.AddTransient<IPeopleServices, PeopleServices>();
            services.AddTransient<IPhonesServices, PhonesServices>();
            services.AddTransient<IPersonNumbersServices, PersonNumbersServices>();
        }

        private void SetupValidators(IServiceCollection services)
        {
            services.AddTransient<IValidator<Phones>, PhoneValidators>();
        }

        private void SetupOData(IServiceCollection services)
        {
            services.AddOData();
        }

        private IEdmModel GetEdmModel()
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EnableLowerCamelCase();

            modelBuilder.EntitySet<People>("People");
            modelBuilder.EntitySet<Phones>("Phones");
            modelBuilder.EntitySet<PersonNumbers>("Person-Numbers");

            return modelBuilder.GetEdmModel();
        }
    }
}
