﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session11.UrlAndRouts.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session11.UrlAndRouts.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        public ViewResult Index()
        {
            return View("Result", new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(Index)
            });
        }

        // GET: /<controller>/
        public ViewResult List()
        {
            return View("Result", new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(List)
            });
        }
    }
}
