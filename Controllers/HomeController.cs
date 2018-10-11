using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coreArch.Models;
using CoreApiClient;
using coreArch.Services;
using Microsoft.Extensions.Logging;

namespace coreArch.Controllers
{
    
    public class HomeController : Controller
    {
         //AngularContext _angularContext;
       private readonly  IApiClient _apiClient;

        // logging default by IloggerFactory
     //   private ILoggerFactory _loggerFactory;

        private ILogger<HomeController> _logger;

        public HomeController(IApiClient apiClient,
            //ILoggerFactory loggerFactory,
            ILogger<HomeController> logger)
        {
            // _angularContext = angularContext;
            _apiClient = apiClient;
            //_loggerFactory = loggerFactory;
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            //var logg = _loggerFactory.CreateLogger("Log Category");
            //logg.LogInformation("checking the logging");
            
            _logger.LogInformation("welcome Nlog");
            var response = await SaveUser();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<JsonResult> SaveUser()
        {
            var model = new Child()
            {
                Id = 0,
                FirstName = "jasmine",
                LastName = "la rose",
                Gender = "female",
                Address = "los Angles",
                BirthDate = DateTime.Now,
                ChildType="Own"
            };
            var response = await _apiClient.SaveUser(model);
            return Json(response);
        }
    }
}
