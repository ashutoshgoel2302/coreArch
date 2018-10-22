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
using coreArch.Repository;
using coreArch.IRepository;

namespace coreArch.Controllers
{

    public class HomeController : Controller
    {

        private readonly IApiClient _apiClient;
        private readonly IApiClientRepository _apiClientRepository;


        private ILogger<HomeController> _logger;

        public HomeController(IApiClient apiClient,

            ILogger<HomeController> logger,
            IApiClientRepository apiClientRepository
            )
        {
            _apiClient = apiClient;
            _logger = logger;
            _apiClientRepository = apiClientRepository;
        }


        public async Task<IActionResult> Index()
        {

            _logger.LogInformation("welcome Nlog");

            var childList = await _apiClientRepository.GetUsers();
            return View(childList);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Child model)
        {
            var response = await _apiClientRepository.SaveUser(model);
            return RedirectToAction("Index");
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

        
        [HttpGet]
        public async Task<IActionResult> Edit(Child child)
        {
            var id = child.Id;
            if(child.Id!=0)
            {
                
                var childDetail =await _apiClientRepository.GetUserById(id);
                return View(childDetail);
            }
            return View();
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> EditDetail(Child model)
        {
            var response = await _apiClientRepository.UpdateUser(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Child model)
        {
            var response = await _apiClientRepository.DeleteUser(model);
            return RedirectToAction("Index");
        }
    }
}
