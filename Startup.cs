using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudentApplication.Models;
using StudentApplication.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using StudentApplication.Models.Repositories;

namespace StudentApplication
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SchoolContext>();
            services.AddMvc();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
        }

       public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger, SchoolContext context)
       {          
            app.UseStaticFiles(); 
            //Log to the console
            logger.AddConsole();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            DbInitializer.Initialize(context);
          
       }
    }
}