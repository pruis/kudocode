using AutoMapper;
using KudoCode.Abstract.Web.Blazor;
using KudoCode.Contracts;
using KudoCode.Contracts.Web;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Web.Blazor.Application.AutoMapper;
using KudoCode.Web.Blazor.Application.Data;
using KudoCode.Web.Blazor.Application.Handlers;
using KudoCode.Web.Blazor.Application.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using VxFormGenerator.Settings.Bootstrap;

namespace KudoCode.Web.Blazor.Application
{
	public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var builder = new ConfigurationBuilder()
            //    //.SetBasePath(env)
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddEnvironmentVariables();
            //var configuration = builder.Build();

            //services.AddSingleton<IConfiguration>(configuration);
            services.AddVxFormGeneratorBootstrap();
            services.AddKudoCodeNavigation();

            services.AddAutoMapper(typeof(Startup).Assembly);


            services.AddKudoCodeNavigation();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperExtensions());

            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //KudoCodeLocalStorageModule
            services.AddRazorPages();
            services.AddHttpContextAccessor();
            services.AddServerSideBlazor().AddCircuitOptions(options => {  options.DetailedErrors = true; });
            services.AddSingleton<IStorage, KudoCodeLocalStorage>();
            services.AddScoped<IApplicationUserContext, ApplicationUserContext>();

            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<WebExecutionPipeline>();
            services.AddSingleton<Api.Connector.Connector>();
            services.AddScoped<ILookupService, LookupService>();
            services.AddScoped<IToastService, ToastService>();
            services.AddScoped<ITokenCache, CsrfHttpTokenCache>();
            services.AddScoped<IApplicationContextHandler, ApplicationContextHandler>();
            services.AddScoped<HttpHandler>();
            services.AddScoped(typeof(ApiPostHandler<,>));
            services.AddScoped<ApiPostController>();
            services.AddScoped<WebHandlerController>();

            services.AddScoped<IWebHandler<GetTokenRequest, int>, GetTokenRequestWebHandler>();
            services
                .AddScoped<IWebHandler<GetListPortfolioRequest, GetListPortfolioViewModel>, GetListPortfolioWebHandler
                >();
            services
                .AddScoped<IWebHandler<GetPortfolioRequest, GetPortfolioViewModel>, GetPortfolioWebHandler
                >();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider provider)
        {

            //ApplicationContextDomain.ApiPostController =(ApiPostController) provider.GetService(typeof(ApiPostController));
                
            app.UseMiddleware<CsrfTokenCookieMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}