﻿using System;
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
    public class CustomersController : AServiceController
    {
		public CustomersController(HttpClient client) : base(client) { }

		// GET: Customer
		public async Task<ActionResult> Index()
		{
			// send "GET api/Temperature" to service, get headers of response
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, "api/Customer");
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
			List<Customer> Customers = JsonConvert.DeserializeObject<List<Customer>>(responseBody);

			return View(Customers);
		}

		// GET: Customer/Details/5
		public async Task<ActionResult> DetailsAsync(int id)
		// send "GET api/Customer" to service, get headers of response
		{
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Customer/{id}");
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
			Customer Customer = JsonConvert.DeserializeObject<Customer>(responseBody);

			return View(Customer);

		}

		// GET: Customer/Create
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
		// POST: Customer/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> CreateAsync(Customer record)
		{
			try
			{

				// use POST method, not GET, based on the route the service has defined
				HttpRequestMessage request = CreateRequestToService(HttpMethod.Post, "api/Customer", record);
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

		// GET: Customer/Edit/5
		public async Task<ActionResult> EditAsync(int id)
		{
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Customer/{id}");
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
			Customer Customer = JsonConvert.DeserializeObject<Customer>(responseBody);

			return View(Customer);
		}

		// POST: Customer/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditAsync(int id, Customer record)
		{
			try
			{

				var url = $"https://localhost:44336/api/Customer/{id}";
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
		// GET: Customer/Delete/5
		public async Task<ActionResult> DeleteAsync(int id)
		{
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Customer/{id}");
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
			Customer Customer = JsonConvert.DeserializeObject<Customer>(responseBody);

			return View(Customer);
		}

		// POST: Customer/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
		{
			try
			{
				var response = await Client.DeleteAsync($"https://localhost:44336/api/Customer/{id}");

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