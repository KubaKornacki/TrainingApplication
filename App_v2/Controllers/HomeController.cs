using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App_v2.Models;
using Microsoft.AspNetCore.Identity;
using App_v2.Repositories;
using App_v2.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App_v2.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IFormRepository _formRepository;

        private readonly IDictRepository _dictRepository;


        public HomeController(UserManager<AppUser> userManager,IFormRepository form,IDictRepository dict)
        {
            _userManager = userManager;
            _formRepository = form;
            _dictRepository = dict;
        }

        public async Task<IActionResult> Index()
        {
            AppUser appUser =await _userManager.GetUserAsync(User);
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




    }
}
