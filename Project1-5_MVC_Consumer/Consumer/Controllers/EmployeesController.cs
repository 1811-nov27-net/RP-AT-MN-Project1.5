using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project1_5_Library;

namespace Consumer.Controllers
{
	public class EmployeesController : AServiceController
	{
		public EmployeesController(HttpClient client) : base(client) { }

		// GET: Employee
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

			return View(Employees);
		}

		// GET: Employee/Details/5
		public async Task<ActionResult> DetailsAsync(int id)
		// send "GET api/Employee" to service, get headers of response
		{
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Employee/{id}");
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
			Employee Employee = JsonConvert.DeserializeObject<Employee>(responseBody);

			return View(Employee);

		}

		// GET: Employee/Create
		public async Task<ActionResult> CreateAsync()
		{
			//	HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, "api/account/loggedinuser");
			//	HttpResponseMessage response = await Client.SendAsync(request);

			//	if (!response.IsSuccessStatusCode)
			//	{
			//		if (response.StatusCode == HttpStatusCode.Unauthorized)
			//		{
			//			return RedirectToAction("Login", "Account");
			//		}
			//		return View("Error");
			//	}

			// provide default value to Create form
			return View();
		}
		// POST: Employee/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> CreateAsync(Employee record)
		{
			try
			{

				// use POST method, not GET, based on the route the service has defined
				HttpRequestMessage request = CreateRequestToService(HttpMethod.Post, "api/Employee", record);
				HttpResponseMessage response = await Client.SendAsync(request);

				if (!response.IsSuccessStatusCode)
				{
					if (response.StatusCode == HttpStatusCode.Unauthorized)
					{
						return RedirectToAction("Login", "Account");
					}
					return View(record);
				}
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(record);
			}
		}

		// GET: Employee/Edit/5
		public async Task<ActionResult> EditAsync(int id)
		{
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Employee/{id}");
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
			Employee Employee = JsonConvert.DeserializeObject<Employee>(responseBody);

			return View(Employee);
		}

		// POST: Employee/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditAsync(int id, Employee record)
		{
			try
			{

				var url = $"https://localhost:44336/api/Employee/{id}";
				var response = await Client.PutAsJsonAsync(url, record);

				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction(nameof(Index));
				}
				return View(record);
			}
			catch
			{
				return View(record);
			}
		}
		// GET: Employee/Delete/5
		public async Task<ActionResult> DeleteAsync(int id)
		{
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Employee/{id}");
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
			Employee Employee = JsonConvert.DeserializeObject<Employee>(responseBody);

			return View(Employee);
		}

		// POST: Employee/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
		{
			try
			{
				var response = await Client.DeleteAsync($"https://localhost:44336/api/Employee/{id}");

				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction(nameof(Index));
				}
				return RedirectToAction(nameof(DeleteAsync), new { id });
			}
			catch
			{
				return RedirectToAction(nameof(DeleteAsync), new { id });
			}
		}
	}
}