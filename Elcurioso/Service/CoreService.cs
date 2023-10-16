using System;
using System.Web;
using Microsoft.AspNetCore.Hosting.Server;
using Newtonsoft.Json;
using WinPizzaData;

namespace Elcurioso.Service
{
	public class CoreService
	{
        public static string BaseUserServiceAddress = @"";

		public static async Task<String> LoadMenuList(string storeID, string imageDomain, string menuID)
		{
			WPMessage wPMessage = new WPMessage();
			wPMessage.DeMsgBody = storeID;
			wPMessage.DataObject = imageDomain;
			wPMessage.DeMsgType = WPUtility.WinPizzaEnums.MessageType.ACTIONSUCCESS;
			wPMessage.WinPizzaObject = menuID;
			string apiDomain = "https://services.tgfpizza.com/ThirdPartyServices/StoreServices.svc";

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
	}
}

