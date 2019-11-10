using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using KudoCode.Web.Api.Connector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using KudoCode.Web.Blazor.Application.Data;
using KudoCode.Web.Blazor.Application.Handlers;
using KudoCode.Web.Infrastructure.Domain.Execution;
using AutoMapper;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Token;
using KudoCode.Web.Blazor.Application.ViewModels;
using KudoCode.Web.Infrastructure.Blazor;
using KudoCode.Web.Infrastructure.Blazor.Extension;
using KudoCode.Web.Infrastructure.Domain;
using KudoCode.Web.Infrastructure.Domain.Handlers;
using KudoCode.Web.Infrastructure.Domain.HttpConnector;

namespace KudoCode.Web.Blazor.Application
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddKudoCodeNavigation();

            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddRazorPages();
            services.AddHttpContextAccessor();
            services.AddServerSideBlazor().AddCircuitOptions(options => {  options.DetailedErrors = true; });
            services.AddSingleton<IStorage, KudoCodeRedisStorage>();
            services.AddScoped<IApplicationUserContext, ApplicationUserContext>();

            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<WebExecutionPipeline>();
            services.AddSingleton<Connector>();

            services.AddScoped<ITokenCache, CsrfTokenCache>();
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}