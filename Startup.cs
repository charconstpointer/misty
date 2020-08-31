using System;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Misty.Extensions;
using Misty.Persistence;

namespace Misty
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);
            services.AddPersistence(Configuration);
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope =
                app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<MistyContext>())
                context?.Database.EnsureCreated();

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "lato"); });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}