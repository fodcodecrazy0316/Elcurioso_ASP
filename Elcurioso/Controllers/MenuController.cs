using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elcurioso.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elcurioso.Controllers
{
    public class MenuController : Controller
    {
        private readonly IConfiguration _config;
        public MenuController(IConfiguration config)
        {
            _config = config;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
          
            return View();
        }

        public async Task<IActionResult> getMenuDetails()
        {
            string storeID = _config.GetSection("StoreID").Value;
            string imageDomain = _config.GetSection("imageDomain").Value;
            string menuID = _config.GetSection("MenuID").Value;
            var result = await CoreService.LoadMenuList(storeID, imageDomain, menuID);
            return Ok(result);
        }
    }
}

