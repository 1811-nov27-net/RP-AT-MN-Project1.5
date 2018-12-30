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
using Consumer.Controllers;

namespace Consumer.Controllers
{
    public class EventsController : AServiceController
    {
		public EventsController(HttpClient client) : base(client) { }

		// GET: Events
		public async Task<ActionResult> Index()
		{
			// send "GET api/Temperature" to service, get headers of response
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, "api/Event");
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
			List<Event> Events = JsonConvert.DeserializeObject<List<Event>>(responseBody);

			return View(Events);
		}

		// GET: Events/Details/5
		public async Task<ActionResult> DetailsAsync(int id)
		// send "GET api/Temperature" to service, get headers of response
		{
		HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Event/{id}");
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
		Event Events = JsonConvert.DeserializeObject<Event>(responseBody);

			return View(Events);
	
}

        // GET: Events/Create
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
		// POST: Events/Create
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Event record)
        {
			try
			{
				
				// use POST method, not GET, based on the route the service has defined
				HttpRequestMessage request = CreateRequestToService(HttpMethod.Post, "api/Event", record);
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

        // GET: Events/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Event/{id}");
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
			Event Event = JsonConvert.DeserializeObject<Event>(responseBody);

			return View(Event);
		}

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Event record)
		{
			try
			{
			
				var url = $"https://localhost:44336/api/Event/{id}";
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
		// GET: Events/Delete/5
		public async Task<ActionResult> DeleteAsync(int id)
        {
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Event/{id}");
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
			Event Event = JsonConvert.DeserializeObject<Event>(responseBody);

			return View(Event);
		}

        // POST: Events/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
        {
			try
			{
				var response = await Client.DeleteAsync($"https://localhost:44336/api/Event/{id}");

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