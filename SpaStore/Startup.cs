namespace SpaStore
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.SpaServices.Webpack;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using Utils;

    /// <summary> Startup. </summary>
    public class Startup
    {
        /// <summary> Constructor. </summary>
        /// <param name="configuration"> config. </param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary> Config. </summary>
        public IConfiguration Configuration { get; }

        /// <summary> This method gets called by the runtime. Use this method to add services to the container. </summary>
        /// <param name="services"> services. </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBasketCalculatorService, BasketCalculatorService>();

            // Add framework services.
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ActionResultExceptionFilter));
            });

            services.AddMvc();
        }

        /// <summary> This method gets called by the runtime. Use this method to configure the HTTP request pipeline. </summary>
        /// <param name="app"> app. </param>
        /// <param name="env"> env. </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
