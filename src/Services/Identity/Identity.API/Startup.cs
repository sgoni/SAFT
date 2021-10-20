using Autofac;
using Identity.API.Infrastructure.AutofacModules;
using Identity.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Identity.API
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

            // Add services to the collection. Don't build or return
            // any IServiceProvider or the ConfigureContainer method
            // won't get called. Don't create a ContainerBuilder
            // for Autofac here, and don't call builder.Populate() - that
            // happens in the AutofacServiceProviderFactory for you.
            services
                .AddCustomDbContext(Configuration)
                .AddCustomSwagger(Configuration)
                .AddHealthChecks(Configuration)
                .AddConfigureIdentity(Configuration)
                .AddAppConfigureCookie(Configuration)
                //.AddMediatR(typeof(Startup).Assembly)
                .AddOptions()
                .AddControllers();
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            string connString = ConfigurationExtensions
                .GetConnectionString(Configuration, "DefaultConnectionString");

            // Register your own things directly with Autofac here. Don't
            // call builder.Populate(), that happens in AutofacServiceProviderFactory
            // for you.
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new ApplicationModule(connString));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //        .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

        //    services.AddControllers();
        //    services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity.API", Version = "v1" });
        //    });
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connString = ConfigurationExtensions
                .GetConnectionString(configuration, "DefaultConnectionString");

            //InMemory
            //services.AddDbContext<EscuelaContext>(
            //    options => options.UseInMemoryDatabase(databaseName: "testDB")
            //);

            //MySQL Pomelo NuGet
            //services.AddDbContextPool<CustomerDBContext>(
            //    options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(connString)));

            //MySQL
            //services.AddDbContext<CustomerDBContext>(
            //    options => options.UseMySQL(connString));

            //SQlServer
            services.AddDbContext<IdentityDBContext>(
                options => options.UseSqlServer(connString));

            services.AddDbContext<IdentityDBContext>(options =>
            {
                options.UseSqlServer(connString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            },
                ServiceLifetime.Scoped); //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Identity.API",
                    Version = "v1"
                });
            });

            return services;
        }

        public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            var hcBuilder = services.AddHealthChecks();

            return services;
        }

        public static IServiceCollection AddConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            return services;
        }

        public static IServiceCollection AddAppConfigureCookie(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            return services;
        }
    }
}
