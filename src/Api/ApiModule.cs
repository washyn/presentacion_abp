using System.Reflection;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.Timing;

namespace Washyn.Kfc
{
    [DependsOn(typeof(ApplicationModule))]
    [DependsOn(typeof(InfrastructureModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpAspNetCoreSerilogModule))]
    [DependsOn(typeof(AbpSwashbuckleModule))]
    [DependsOn(typeof(AbpAutofacModule))]
    public class ApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var services = context.Services;
            var env = context.Services.GetHostingEnvironment();

            Configure<AbpClockOptions>(options => { options.Kind = DateTimeKind.Utc; });
            ConfigureSwaggerServices(context, configuration);

            services.AddHealthChecks()
                .AddCheck<DbHealthCheck>("database");
            
            Configure<AbpAspNetCoreMvcOptions>(opt =>
            {
                // opt.ConventionalControllers.Create(typeof(ApplicationModule).Assembly, opts =>
                // {
                //     opts.UseV3UrlStyle = true;
                // });
            });
        }

        private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
        {
            // https://editor.swagger.io/
            context.Services
                .AddAbpSwaggerGen()
                .ConfigureSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "App API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
                });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseUnitOfWork();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseAbpSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "App API"); });
            app.UseAbpSerilogEnrichers();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
            app.UseConfiguredEndpoints();
        }
    }
}