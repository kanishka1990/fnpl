using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Web.Mvc;

namespace FlynowPaylaterWebApp
{
    public class Startup
    {
       
        public IConfiguration Configuration;
        public IHostingEnvironment _env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
            _env = env;
            this.Configuration = configuration;
        }

    

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          string origin = Configuration.GetValue<string>("MyAppSettings:appOrigin");
            string clientorigin = Configuration.GetValue<string>("MyAppSettings:clientOrigin");

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",

                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                        builder.WithOrigins(clientorigin,
                                "https://widget.flynowpaylater.com").AllowAnyHeader().AllowAnyMethod();
                        builder.WithOrigins(origin,
                               "https://widget.flynowpaylater.com").AllowAnyHeader().AllowAnyMethod();

                    });

            });

          //  services.Configure<SagePayConfig>(Configuration.GetSection("SagePayConfig"));
            
            services.AddControllersWithViews();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        private void CheckSameSite(HttpContext httpContext, CookieOptions options)
        {
            if (options.SameSite == Microsoft.AspNetCore.Http.SameSiteMode.None)
            {
                var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
                options.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
                // TODO: Use your User Agent library of choice here.
                //if (/* UserAgent doesn’t support new behavior */)
                //{
                //    // For .NET Core < 3.1 set SameSite = (SameSiteMode)(-1)
                //    options.SameSite = SameSiteMode.Unspecified;
                //}
            }
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //  app.UseHttpsRedirection();
            app.UseSession();
            app.UseRouting();
            app.UseCors("AllowMyOrigin");
            app.UseAuthorization();
            app.UseStaticFiles();
                   
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id}", // URL with parameters
 new { controller = "Home", action = "Index", id = UrlParameter.Optional });

               

            });


        }
    }
}
