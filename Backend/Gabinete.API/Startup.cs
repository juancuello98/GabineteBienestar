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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Reflection;
using Gabinete.Persistence.EFramework.context;
using Gabinete.Domain.Repositorie;
using Gabinete.Application.BusinessLogica;

namespace Gabinete.API
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
            //services.AddAutoMapper(Assembly.Load("Gabinete.Infrastructure.Automapper"));
            services.AddControllers();
            services.AddDbContext<GabineteContext>(conf => conf.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddControllers().AddNewtonsoftJson(c => c.UseMemberCasing());
            services.AddControllers();

            services.AddTransient<AlumnoRepository>();
            services.AddTransient<AlumnoBusinessLogic>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
