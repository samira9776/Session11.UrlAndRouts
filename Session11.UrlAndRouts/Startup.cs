using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using Session11.UrlAndRouts.Infrastructures;

namespace Session11.UrlAndRouts
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options => {
                options.ConstraintMap.Add("WeekDay", typeof(WeekdayConstraint));
                options.LowercaseUrls=true;
                options.AppendTrailingSlash=true;
                
                });
            
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();/*اگر نباشد، صفحه خطایی که برای 400 نشوند میده، صفحه دیفالت برازر است.ولی اگر باشد دیفالت ای اس پی دات نت برمیگردد*/
            app.UseStaticFiles();
            //app.UseMvc();
            //app.UseMvc(routs => { routs.MapRoute("default", "/{controller}/{action}"); });

            //app.UseMvc(routs => { routs.MapRoute("default", "/{controller=Home}/{action=Index}"); });

            //app.UseMvc(routs => { routs.MapRoute("default", "/{controller}/{action}",
            //    defaults:new {controller="Home",action="Index" }); });

            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "TestStaticSegment/{controller=home}/{action=index}");
            //});

            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/q{controller=home}/{action=index}");
            //});

            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("old", "/news",defaults:new {controller="content",action="index" });
            //    routs.MapRoute("default", "/{controller=home}/{action=index}");
            //});

            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id=testID}");
            //});

            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id?}");
            //});


            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id}/{*catchall}");
            //});


            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id:int}");
            //});

            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id:alpha}");
            //});

            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id}" , defaults:new { } ,constraints:new {id=new AlphaRouteConstraint()});
            //});


            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id:length(3)}");
            //});

            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id:Maxlength(3)}");
            //});

            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id:int:Range(1,100)}");
            //});

            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id}", defaults: new { },
            //        constraints:new {id= new WeekdayConstraint() });
            //});

            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{action=index}/{controller=home}/{id:WeekDay=sat}");
            //});

            //app.UseMvc(routs =>
            //{
            //    routs.Routes.Add(new MyCustomRouter("/articles/windows_3.1_OverView.html", "/old/.NET_1.0_Class_Library")    );
            //    routs.MapRoute("default", "/{action=index}/{controller=home}/{id:WeekDay=sat}");
            //});


            app.UseMvc(routs =>
            {
                routs.Routes.Add(new MyCustomRouter2(app.ApplicationServices,"/articles/windows_3.1_OverView.html", "/old/.NET_1.0_Class_Library"));
                routs.MapRoute("default", "/{action=index}/{controller=home}/{id:WeekDay=sat}");
            });
        }
    }
}
