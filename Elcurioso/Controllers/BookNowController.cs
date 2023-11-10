using Elcurioso.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elcurioso.Controllers
{
    public class BookNowController : Controller
    {
        private readonly IConfiguration _config;

        public string timezone;
        public string storeID;
        public string userPinMsg;

        public BookNowController(IConfiguration config)
        {
            _config = config;
            timezone = _config.GetSection("TimeZone").Value;
            storeID = _config.GetSection("StoreID").Value;
            userPinMsg = _config.GetSection("UsePinMsg").Value;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> getTimesList(string currentTime)
        {
            string trimmedTime = currentTime.Replace("\"", "");
            var result = await CoreService.GetBookingTimeAv(timezone, storeID, trimmedTime);
            return Ok(result);
        }


        public async Task<IActionResult> setVerifyPin(string phoneNumber)
        {
            var result = await CoreService.SendVerifyPin(phoneNumber, storeID, userPinMsg);
            return Ok(result);
        }

        public async Task<IActionResult> IsPINValid(string pinCode, string phoneNumber)
        {
            var result = await CoreService.IsPinValid(pinCode, storeID, phoneNumber);
            return Ok(result);
        }
    }
}

