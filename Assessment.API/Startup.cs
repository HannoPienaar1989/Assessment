using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Assessment.BL.Interfaces;
using Assessment.DL.Repositories;
using Assessment.BL.Implementations;
using Assessment.DL;
using AutoMapper;
using Assessment.DL.Profiles;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using NLog;

namespace Assessment.API
{
    public class Startup
    {
       
        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddDbContext<DBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Conn"), b => b.MigrationsAssembly("Assessment.API"))
            );
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<ITicketService, TicketService>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddTransient<IListService, ListService>();
            services.AddScoped<IListRepository, ListRepository>();
  
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3001",
                                                          "http://localhost:3000")
                                                          .AllowAnyHeader()
                                                          .AllowAnyMethod();
                                  });
            });
            services.AddMvc(option => {
                option.EnableEndpointRouting = false;
                option.RespectBrowserAcceptHeader = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(
        options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
