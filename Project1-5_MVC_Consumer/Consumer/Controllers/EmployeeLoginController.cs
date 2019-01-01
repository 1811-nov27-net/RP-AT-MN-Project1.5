using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Consumer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project1_5_Library;

namespace Consumer.Controllers
{
    public class EmployeeLoginController : AServiceController
    {

		public EmployeeLoginController(HttpClient client) : base(client) { }

		// GET: EmployeeLogin

		public async Task<ActionResult> Index()
			{
				// send "GET api/Employee" to service, get headers of response
				HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, "api/Employee");
				HttpResponseMessage response = await Client.SendAsync(request);

				//// (if status code is not 200-299 (for success))
				//if (!response.IsSuccessStatusCode)
				//{
				//	if (response.StatusCode == HttpStatusCode.Unauthorized)
				//	{
				//		return RedirectToAction("Login", "Account");
				//	}
				//	return RedirectToAction("Error", "Home");
				//}

				// get the whole response body (second await)
				var responseBody = await response.Content.ReadAsStringAsync();


				// this is a string, so it must be deserialized into a C# object.
				// we could use DataContractSerializer, .NET built-in, but it's more awkward
				// than the third-party Json.NET aka Newtonsoft JSON.
				List<Employee> Employees = JsonConvert.DeserializeObject<List<Employee>>(responseBody);

			LoginView model = new LoginView();
			model.Employees = Employees;

				return View(model);
			}

		}

		
    }
