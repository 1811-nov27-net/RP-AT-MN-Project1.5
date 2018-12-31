using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Consumer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project1_5_Library;


namespace Consumer.Controllers
{
	public class ReservationsController : AServiceController
	{
		public ReservationsController(HttpClient client) : base(client) { }

		// GET: Reservations
		public async Task<ActionResult> Index()
		{
			// send "GET api/Temperature" to service, get headers of response
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, "api/Reservation");
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
			List<Reservation> Reservations = JsonConvert.DeserializeObject<List<Reservation>>(responseBody);

			return View(Reservations);
		}

		// GET: Reservations/Details/5
		public async Task<ActionResult> DetailsAsync(int id)
		// send "GET api/Temperature" to service, get headers of response
		{
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Reservation/{id}");
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
			Reservation Reservations = JsonConvert.DeserializeObject<Reservation>(responseBody);

			return View(Reservations);

		}

		// GET: Reservations/Create
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

            //Get All Customers
            HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Customer");
            HttpResponseMessage response = await Client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();
            List<Customer> customersList = JsonConvert.DeserializeObject<List<Customer>>(responseBody);

            ReservationView model = new ReservationView();
            model.CustomerList = customersList;

            return View(model);
		}
		// POST: Reservations/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> CreateAsync(Reservation record)
		{
			try
			{

				// use POST method, not GET, based on the route the service has defined
				HttpRequestMessage request = CreateRequestToService(HttpMethod.Post, "api/Reservation", record);
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

		// GET: Reservations/Edit/5
		public async Task<ActionResult> EditAsync(int id)
		{
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Reservation/{id}");
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
			Reservation Reservation = JsonConvert.DeserializeObject<Reservation>(responseBody);

            //Set Values to View
            ReservationView model = new ReservationView();
            model.Id = Reservation.Id;
            model.CustomerId = Reservation.CustomerId;
            model.StartDate = Reservation.StartDate;
            model.EndDate = Reservation.EndDate;
            model.TotalCost = Reservation.TotalCost;
            
            //Get Customers list
            request = CreateRequestToService(HttpMethod.Get, $"api/Customer");
            response = await Client.SendAsync(request);
            responseBody = await response.Content.ReadAsStringAsync();
            List<Customer> customersList = JsonConvert.DeserializeObject<List<Customer>>(responseBody);
            model.CustomerList = customersList;

            //Get Customer
            request = CreateRequestToService(HttpMethod.Get, $"api/Customer/{Reservation.CustomerId}");
            response = await Client.SendAsync(request);
            responseBody = await response.Content.ReadAsStringAsync();
            Customer customer = JsonConvert.DeserializeObject<Customer>(responseBody);
            model.Customer = customer;

            //Get Room
            request = CreateRequestToService(HttpMethod.Get, $"api/Room/{Reservation.RoomId}");
            response = await Client.SendAsync(request);
            responseBody = await response.Content.ReadAsStringAsync();
            Room room = JsonConvert.DeserializeObject<Room>(responseBody);
            model.Room = room;
            model.roomSelectString = $"<option value='{room.Id}'>{room.Id} {String.Format("{0:0.00}", room.Cost)} ({room.RoomType})</option>";

            return View(model);
		}

		// POST: Reservations/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditAsync(int id, Reservation record)
		{
			try
			{

				var url = $"https://localhost:44336/api/Reservation/{id}";
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
		// GET: Reservations/Delete/5
		public async Task<ActionResult> DeleteAsync(int id)
		{
			HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/Reservation/{id}");
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
			Reservation Reservations = JsonConvert.DeserializeObject<Reservation>(responseBody);

			return View(Reservations);
		}

		// POST: Reservations/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
		{
			try
			{
				var response = await Client.DeleteAsync($"https://localhost:44336/api/Reservation/{id}");

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