using KudoCode.Contracts;
using KudoCode.Contracts.Web;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using KudoCode.LogicLayer.Dtos.Portfolios.Inbound;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Inbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactions.Outbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Inbound;
using KudoCode.LogicLayer.Dtos.PortfolioTransactionsSummaries.Outbound;
using KudoCode.Web.Application.Handlers;
using KudoCode.Web.Application.Handlers.Portfolios;
using KudoCode.Web.Application.Handlers.PortfolioTransactions;
using KudoCode.Web.Application.Handlers.PortfolioTransactionsSummary;
using KudoCode.Web.Application.Models.Lead;
using KudoCode.Web.Application.Models.LeadScheduledActivity;
using KudoCode.Web.Application.Models.Portfolios;
using KudoCode.Web.Application.Models.PortfolioTransactions;
using KudoCode.Web.Application.Models.PortfolioTransactionsSummary;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KudoCode.Web.Application
{
	public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JsonConvert.DefaultSettings = () => Json.Serialization.Auto();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //singleton per app pool ?
            //services.AddSingleton(new Connector());

            //services.AddSingleton<Connector>();
            //services.AddJson( );
            services.AddMemoryCache();
            services.AddMvc(options => options.EnableEndpointRouting = false );
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddMvc(config =>
            {
               // config.ModelBinderProviders.Insert(0, new InvariantDecimalModelBinderProvider());
            });
            //services.AddCookieAuthentication();
            services.AddHttpContextAccessor();

            services.AddScoped<Api.Connector.Connector>();
            services.AddScoped<HttpHandler>();

            services.AddScoped<ApiPostController>();		
            services.AddSingleton<ITokenCache, CsrfHttpTokenCache>();

            services.AddScoped<IApplicationUserContext, ApplicationUserContext>();

            services.AddScoped<IApplicationContextHandler, ApplicationContextHandler>();

            services.AddScoped<IStorage, KudoCodeLocalStorage>();
            //services.AddScoped<IStorage,KudoCodeRedisStorage>();
            services.AddScoped<WebTokenAuthorizationAttribute>();
            services.AddScoped<WebExecutionPipeline>();
            services.AddScoped<IWebHandler<GetListLeadRequest, List<GetLeadResponse>>, LeadsWebHandler>();
            services.AddScoped<IWebHandler<GetLeadRequest, LeadViewModel>, LeadWebHandler>();
            services.AddScoped<IWebHandler<LeadViewModel, int>, LeadWebHandler>();
            services.AddScoped<IWebHandler<Get, LeadScheduledActivityViewModel>, LeadScheduledActivityWebHandler>();
            services.AddScoped<IWebHandler<LeadScheduledActivityViewModel, int>, LeadScheduledActivityWebHandler>();
            services.AddScoped<IWebHandler<GetPortfolioRequest, GetPortfolioViewModel>, GetPortfolioWebHandler>();
            services
                .AddScoped<IWebHandler<GetListPortfolioRequest, GetListPortfolioViewModel>, GetListPortfolioWebHandler
                >();
            services
                .AddScoped<IWebHandler<GetListPortfolioTransactionsSummaryRequest,
                        GetListPortfolioTransactionsSummaryViewModel>,
                    GetListPortfolioTransactionsSummaryWebHandler>();
            services
                .AddScoped<IWebHandler<GetPortfolioTransactionsSummaryRequest,
                        GetPortfolioTransactionsSummaryViewModel>,
                    GetPortfolioTransactionsSummaryWebHandler>();

            services.AddScoped<IWebHandler<SavePortfolioRequest, int>, SavePortfolioWebHandler>();

            services
                .AddScoped<IWebHandler<SavePortfolioTransactionsSummaryRequest, int>,
                    SavePortfolioTransactionsSummaryWebHandler>();

            services
                .AddScoped<IWebHandler<GetPortfolioTransactionRequest, GetPortfolioTransactionViewModel>,
                    GetPortfolioTransactionWebHandler>();

            services
                .AddScoped<IWebHandler<SavePortfolioTransactionRequest, int>,
                    SavePortfolioTransactionWebHandler>();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

//                routes.MapRoute(
//                    name: "PortfolioTransaction",
//                    template: "{controller=PortfolioTransaction}/{action=Edit}/{id:int}/{portfolioId:int}");

                routes.MapRoute(
                    name: "EditLeadScheduledActivity",
                    template: "{controller=LeadScheduledActivity}/{action=Edit}/{id:int}/{leadId:int}");
            });
        }
    }
}