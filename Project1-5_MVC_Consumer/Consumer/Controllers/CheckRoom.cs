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
    public class CheckRoomController : AServiceController
    {
		public CheckRoomController(HttpClient client) : base(client)
		{
		}
        
        // GET: Rooms/GetAvailableRoomSelectBoxAsync/2018-12-26
        public async Task<string> GetAvailableRoomSelectBoxAsync(int id)
        {
            HttpRequestMessage request = CreateRequestToService(HttpMethod.Get, $"api/RoomAvailable/{id}");
            HttpResponseMessage response = await Client.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();
            List<Room> roomList = JsonConvert.DeserializeObject<List<Room>>(responseBody);

            String ret = "";

            foreach(var item in roomList)
            {
                ret += $"<option value='{item.Id}'>{item.Id} {String.Format("{0:0.00}", item.Cost)} ({item.RoomType})</option>";
            }

            return ret;
        }
    }
}