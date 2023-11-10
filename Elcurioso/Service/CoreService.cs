using WinPizzaData;

namespace Elcurioso.Service
{
	public class CoreService
	{
        public static string apiDomain = "https://services.tgfpizza.com/ThirdPartyServices/StoreServices.svc";

        public static async Task<String> LoadMenuList(string storeID, string imageDomain, string menuID)
		{
			string param = "{" + String.Format("%22DeMsgBody%22:%22{0}%22,%22DataObject%22:%22{1}%22,%22DeMsgType%22:{2},%22WinPizzaObject%22:%22{3}%22",
				storeID, imageDomain, 6, menuID) + "}";

            string endPoint = string.Format("{0}/LoadMenu?Data={1}", apiDomain, param);

            var res = await LoadStoreHelperFunctoin.DoWebJsonServices(endPoint);
			if (res.DeMsgType == WPUtility.WinPizzaEnums.MessageType.ACTIONSUCCESS)
			{
				return (string)res.WinPizzaObject;
			}

			return null;
        }

		public static async Task<String> GetBookingTimeAv(string timeZone, string storeID, string unFormatedDate)
		{
			string param = "{" + String.Format("%22DataObject%22:%22{0}%22,%22DeMsgBody%22:%22{1}%22,%22DeMsgType%22:{2},%22WinPizzaObject%22:%22{3}%22",
                Uri.EscapeDataString(timeZone), storeID, 6, unFormatedDate) + "}";

			string endPoint = string.Format("{0}/GetBookingTimeAv?Data={1}", apiDomain, param);

			var res = await LoadStoreHelperFunctoin.DoWebJsonServices(endPoint);
			if (res.DeMsgType == WPUtility.WinPizzaEnums.MessageType.ACTIONSUCCESS)
			{
				return (string)res.WinPizzaObject;
			}

			return null;
		}

		public static async Task<String> SendVerifyPin(string phoneNumber, string storeID, string confirmPinTxt)
		{
			string param = "{" + String.Format("%22DataObject%22:%22%{0}%22,%22DeMsgBody%22:%22{1}%22,%22DeMsgType%22:{2},%22WinPizzaObject%22:%22{3}%22",
				phoneNumber, storeID, 6, Uri.EscapeDataString(confirmPinTxt)) + "}";

            string endPoint = string.Format("{0}/SendVerifyPin?Data={1}", apiDomain, param);

			var res = await LoadStoreHelperFunctoin.DoWebJsonServices(endPoint);
			if(res.DeMsgType == WPUtility.WinPizzaEnums.MessageType.ACTIONSUCCESS)
			{
				return (string)res.WinPizzaObject;
			}

			return null;
		}

		public static async Task<String> IsPinValid(string pinCode, string storeID, string phoneNumber)
		{
			string param = "{" + String.Format("%22DataObject%22:%22{0}%22,%22DeMsgBody%22:%22{1}%22,%22DeMsgType%22:{2},%22WinPizzaObject%22:%22{3}%22",
				pinCode, storeID, 6, phoneNumber) + "}";

			string endPoint = string.Format("{0}/IsPINValid?Data={1}", apiDomain, param);

			var res = await LoadStoreHelperFunctoin.DoWebJsonServices(endPoint);

			if(res.DeMsgType == WPUtility.WinPizzaEnums.MessageType.ACTIONSUCCESS)
			{
				return (string)res.WinPizzaObject;
			}

			return null;
		}
	}
}

