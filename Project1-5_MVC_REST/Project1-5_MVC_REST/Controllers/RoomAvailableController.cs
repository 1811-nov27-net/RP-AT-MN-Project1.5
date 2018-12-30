using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1_5_DataAccess;
using Project1_5_Library;
using Project1_5_Library.RepoInterfaces;

namespace Project1_5_MVC_REST.Controllers
{
    public class RoomAvailableController : Controller
    {
        private IRoomRepository Repository { get; set; }

        public RoomAvailableController(IRoomRepository _respository)
        {
            Repository = _respository;
        }

        // GET: api/RoomAvailable/aaaa-MM-dd
        [HttpGet("{stringDate}", Name = "CheckRoomAvailability")]
        [Route("api/RoomAvailable/{stringDate}")]
        public ActionResult<IList<Room>> CheckRoomAvailability(string stringDate)
        {
            try
            {
                DateTime date = DateTime.Parse(stringDate);
                List<Room> list = (List<Room>)Repository.CheckRoomAvailability(date);
                return list;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}