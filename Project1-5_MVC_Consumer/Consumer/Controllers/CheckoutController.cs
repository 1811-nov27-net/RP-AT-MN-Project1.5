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
    public class CheckoutController : AServiceController
    {

        public CheckoutController(HttpClient client) : base(client) { }

        // GET: Checkout/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        // send "GET api/Customer" to service, get headers of response
        {
            CheckoutView model = new CheckoutView();
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
            Reservation reservation = JsonConvert.DeserializeObject<Reservation>(responseBody);

            model.Reservation = reservation;

            //Get all events by customer
            request = CreateRequestToService(HttpMethod.Get, $"api/CustomerEvents/{reservation.CustomerId}");
            response = await Client.SendAsync(request);
            responseBody = await response.Content.ReadAsStringAsync();
            List<EventCustomer> eventsCustomer = JsonConvert.DeserializeObject<List<EventCustomer>>(responseBody);
            model.EventsCustomer = eventsCustomer;


            //Total Cost
            request = CreateRequestToService(HttpMethod.Get, $"api/Checkout/{id}");
            response = await Client.SendAsync(request);
            responseBody = await response.Content.ReadAsStringAsync();
            decimal cost = JsonConvert.DeserializeObject<decimal>(responseBody);
            model.TotalCost = cost;

            return View(model);

        }


        // POST: Checkout/Checkout/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckoutAsync(int id, Reservation record)
        {
            try
            {
                var url = $"https://localhost:44336/api/Checkout/{id}";
                var response = await Client.PutAsJsonAsync(url, record);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Reservations");
                }
                return RedirectToAction(nameof(DetailsAsync), new { id });
            }
            catch
            {
                return RedirectToAction(nameof(DetailsAsync), new { id });
            }
        }
    }
}