﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RadniNalog.Data;
using RadniNalog.Models;
using RadniNalog.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Rotativa.AspNetCore;

namespace RadniNalog
{
    public class Startup
    {
        

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("hosting.json", optional: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
               // builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
               // builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public  void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
           // services.AddApplicationInsightsTelemetry(Configuration);


            /*Dodavanje servisa za interakciju s  MSSQLbazom u INJECT KONTAINER*/
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //services.AddDbContext<ApplicationDbContext>(options =>
            //   options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));




            /*Servis koji obavlja sve vezano uz autentifikaciju i autorizaciju.
             Ima mnostvo opcija za nacine logiranja,redirekcije itd....*/
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();



            //NOVO U DOTNET CORE 2
            services.ConfigureApplicationCookie(options => {
                options.LoginPath = new PathString("/Account/Login");
                options.AccessDeniedPath = new PathString("/Account/Authorization");
            }
            );

            services.AddMvc();
            //    .AddJsonOptions(
            //options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore ); ;

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddTransient<IFillRole, FillRole>();

            //services.AddSingleton<PdfResultExecutor>();

            services.AddNodeServices();
           

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public  void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,IFillRole fillRole)
        { 

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();


            //obsolete
            // app.UseIdentity();
            app.UseAuthentication();


            app.UsePathBase("/RNalog");

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });



            fillRole.fillNalog();
            fillRole.createRolesandUsers();



            // var webRootPath = env.WebRootPath;
            // call rotativa conf passing env to get web root path
            RotativaConfiguration.Setup(env);


        }

        // In this method we will create default User roles and Admin user for login   

    }
}
