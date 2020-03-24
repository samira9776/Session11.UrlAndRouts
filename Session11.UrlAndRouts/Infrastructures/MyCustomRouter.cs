using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session11.UrlAndRouts.Infrastructures
{

    public class MyCustomRouter : IRouter
    {
        private string[] urls;
        public MyCustomRouter(params string[] targetUrls)/*فرض میکند که این آدرس ها ، قدیمی هستند*/
        {
            this.urls = targetUrls;
        }
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }

        public Task RouteAsync(RouteContext context)
        {
            string requestedUrl = context.HttpContext.Request.Path.Value.TrimEnd('/');
            if (urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                context.Handler = async ctx =>
                {
                    HttpResponse response = ctx.Response;
                    byte[] bytes = Encoding.ASCII.GetBytes($"URL:{requestedUrl}");
                    await response.Body.WriteAsync(bytes, 0, bytes.Length);

                };

            }
            return Task.CompletedTask;
        }
    }


    public class MyCustomRouter2 : IRouter
    {

        private string[] urls;
        private IRouter mvcRoute;
        public MyCustomRouter2(IServiceProvider service, params string[] targetUrls)/*فرض میکند که این آدرس ها ، قدیمی هستند*/
        {

            this.urls = targetUrls;
            mvcRoute = service.GetRequiredService<MvcRouteHandler>();
        }
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }

        public async Task RouteAsync(RouteContext context)
        {
            string requestedUrl = context.HttpContext.Request.Path.Value.TrimEnd('/');
            if (urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                context.RouteData.Values["controller"] = "Custom";
                context.RouteData.Values["action"] = "Index";
                context.RouteData.Values["MyCustomRouteurl"] = requestedUrl;
                await mvcRoute.RouteAsync(context);

            }

        }
    }
}
