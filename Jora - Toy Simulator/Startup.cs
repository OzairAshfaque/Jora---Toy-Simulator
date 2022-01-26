using Data.Service;
using Data.Service.Interface;
using Data.Service.Services;
using Data.Services.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Jora___Toy_Simulator
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
            services.AddTransient<IToyRobotService, ToyRobotService>();
            services.AddTransient<ICommandParserService, CommandParserService>();
            services.AddTransient<IToyRobotBehaviourService, ToyRobotBehaviourService>();
            
            //services.AddDistributedMemoryCache();
            //services.AddSession(options => {
            //    options.IdleTimeout = TimeSpan.FromMinutes(30);//You can set Time   
            //});

            services.AddCors(options => 
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

         //   app.UseSession();
            app.UseCors();
            app.UseStaticFiles();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

    
        }
    }
}
