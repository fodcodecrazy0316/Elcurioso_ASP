using Elcurioso.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elcurioso.Controllers
{
    public class BookNowController : Controller
    {
        private readonly IConfiguration _config;
        public BookNowController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> getTimesList(string currentTime)
        {
            string trimmedTime = currentTime.Replace("\"", "");
            string timezone = _config.GetSection("TimeZone").Value;
            string storeID = _config.GetSection("StoreID").Value;
            var result = await CoreService.GetBookingTimeAv(timezone, storeID, trimmedTime);
            return Ok(result);
        }
    }
}

