using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1_5_Library;
using Project1_5_Library.RepoInterfaces;

namespace Project1_5_MVC_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomRepository Repository { get; set; }

        public RoomController(IRoomRepository _respository)
        {
            Repository = _respository;
        }

        // GET: api/Room
        [HttpGet]
        public ActionResult<IList<Room>> Get()
        {
            try
            {
                List<Room> list = (List<Room>)Repository.GetAll();
                return list;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET: api/Room/5
        [HttpGet("{id}", Name = "GetRoom")]
        public ActionResult<Room> Get(int id)
        {
            Room roomDB;
            try
            {
                roomDB = Repository.GetById(id);
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            if (roomDB == null)
            {
                return NotFound(); // if resource doesn't exist, i'll return an error
            }
            return roomDB; // success = Ok()
        }

        // POST: api/Room
        [HttpPost]
        public ActionResult Post([FromBody] Room room)
        {
            try
            {
                room = Repository.Create(room);
                Repository.SaveChanges();
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            // return proper 201 Created response, based on correct route for get-by-ID,
            // and return the representation of the object.
            return CreatedAtRoute("GetRoom", new { id = room.Id }, room);
        }

        // PUT: api/Room/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Room room)
        {
            Room roomDB;
            try
            {
                roomDB = Repository.GetById(id);
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            if (roomDB == null)
            {
                return NotFound(); // if resource doesn't exist, i'll return an error
            }
            if (id != roomDB.Id)
            {
                return BadRequest("cannot change ID");
            }
            try
            {
                Repository.Update(room, id);
                Repository.SaveChanges();
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            // return proper 204 No Content response
            return NoContent(); // success = Ok()
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Room roomDB;
            try
            {
                roomDB = Repository.GetById(id);
                if (roomDB == null)
                {
                    return NotFound(); // if resource doesn't exist, i'll return an error
                }
                roomDB = null;

                Repository.Delete(id);
                Repository.SaveChanges();
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            // return proper 204 No Content response
            return NoContent(); // success = Ok()
        }

        // GET: api/Room/2018-12-25
        //[HttpGet("{beginDate}", Name = "CheckRoomAvailable")]
        //public ActionResult<IList<Room>> CheckRoomAvailability(DateTime beginDate)
        //{
        //    try
        //    {
        //        List<Room> list = (List<Room>)Repository.CheckRoomAvailability(beginDate);
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex);
        //    }
        //}
    }
}
