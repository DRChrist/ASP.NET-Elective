using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace StudentApplication
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

       public void Configure(IApplicationBuilder app, ILoggerFactory logger)
       {           
            //Log to the console
            logger.AddConsole();
            app.UseMvcWithDefaultRoute();
          
       }
    }
}