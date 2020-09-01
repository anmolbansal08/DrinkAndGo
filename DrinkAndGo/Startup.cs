using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using DrinkAndGo.Data;
using Microsoft.EntityFrameworkCore;
//sing DrinkAndGo.Data.Repositories;
using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Data.Models;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data.SqlClient;
using DrinkAndGo.Data.Models.mocks;

namespace DrinkAndGo
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure youar application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddTransient<IDrinkRepository, MockDrinkRepository>();
            services.AddTransient<ICategoryRepository, MockCategoryRepository>();

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
           //loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
           // app.UseIdentity();

        }
    }
}
