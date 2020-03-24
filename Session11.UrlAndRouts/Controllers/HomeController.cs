using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session11.UrlAndRouts.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session11.UrlAndRouts.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        //public ViewResult Index()
        //{
        //    //return View("Result",new Result { 
        //    //     Controller=nameof(HomeController),
        //    //     Action=nameof(Index)});


        //    //taghir baraye routData and id
        //    Result result = new Result { Action = nameof(Index), Controller = nameof(HomeController) };
        //    result.Data["id"] = RouteData.Values["id"];
        //    result.Data["catchall"] = RouteData.Values["catchall"]; ;

        //    return View("Result", result);
        //}

        public ViewResult Index( string id)
        {
            //ravesh model builder
            Result result = new Result { Action = nameof(Index), Controller = nameof(HomeController) };
            result.Data["id"] =id;
            //result.Data["catchall"] = RouteData.Values["catchall"]; 

            return View("Result", result);
        }

        [Route("/testattr")]
        public ViewResult Index2(string id)
        {
            //Url.Action("", "", new { });
            //ravesh model builder
            Result result = new Result { Action = nameof(Index2), Controller = nameof(HomeController) };
            result.Data["id"] = id;
            //result.Data["catchall"] = RouteData.Values["catchall"]; 

            return View("Result", result);
        }
    }
}
