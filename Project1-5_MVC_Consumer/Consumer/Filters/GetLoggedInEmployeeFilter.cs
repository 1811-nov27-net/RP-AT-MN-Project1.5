using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Consumer.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Consumer.Filters
{ 
	public class GetLoggedInEmployeeFilter : IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(
						ActionExecutingContext context,
						ActionExecutionDelegate next)
		{

			var controller = context.Controller as AServiceController;
			if (controller != null)
			{
				HttpRequestMessage request = controller.CreateRequestToService(HttpMethod.Get, "api/Employee/loggedinuser");
				HttpResponseMessage response = await controller.Client.SendAsync(request);

				if (!response.IsSuccessStatusCode)
				{
					controller.ViewBag.LoggedInUser = "";
				}
				controller.ViewBag.LoggedInUser = await response.Content.ReadAsStringAsync();
				//puts logged in user into view bag
			}
					var resultContext = await next();
		}
	}
}
