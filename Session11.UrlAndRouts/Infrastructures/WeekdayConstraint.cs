using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session11.UrlAndRouts.Infrastructures
{
    public class WeekdayConstraint : IRouteConstraint
    {
        private static string[] Day = new[] { "mon","tue","wed","thu","fri","sat","sun"};
        public bool Match(HttpContext httpContext, IRouter route, string routeKey,
            RouteValueDictionary values, RouteDirection routeDirection)
        {

            return Day.Contains(values[routeKey]?.ToString().ToLowerInvariant());
        }
    }
}
