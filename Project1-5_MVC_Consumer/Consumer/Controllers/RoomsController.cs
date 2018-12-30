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
    public class RoomsController : AServiceController
    {
		public RoomsController(HttpClient client) : base(client)
		{
		}

		// GET: Rooms
		public async Task<ActionResult> Index()
		{
			// send "GET api/Room" to service, get headers of response
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, "api/Room");
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
			List<Room> Rooms = JsonConvert.DeserializeObject<List<Room>>(responseBody);

			return View(Rooms);
		}

		// GET: Room/Details/5
		public async Task<ActionResult> DetailsAsync(int id)
		// send "GET api/Temperature" to service, get headers of response
		{
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Room/{id}");
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
			Room Room = JsonConvert.DeserializeObject<Room>(responseBody);

			return View(Room);

		}

		// GET: Room/Create
		public async Task<ActionResult> CreateAsync() //commet outto makesynchronous to create view
		//public ActionResult Create() - some issues were going on here tring going back to asyncs
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
		// POST: Room/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> CreateAsync(Room record)
		{
			try
			{

				// use POST method, not GET, based on the route the service has defined
				HttpRequestMessage request = CreateRequestToService(HttpMethod.Post, "api/Room", record);
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
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Room/{id}");
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
			Room Room = JsonConvert.DeserializeObject<Room>(responseBody);

			return View(Room);
		}

		// POST: Room/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditAsync(int id, Room record)
		{
			try
			{

				var url = $"https://localhost:44336/api/Room/{id}";
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
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Room/{id}");
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
			Room Room = JsonConvert.DeserializeObject<Room>(responseBody);

			return View(Room);
		}

		// POST: Room/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
		{
			try
			{
				var response = await Client.DeleteAsync($"https://localhost:44336/api/Room/{id}");

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