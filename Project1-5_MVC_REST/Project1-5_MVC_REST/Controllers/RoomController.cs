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
        public async Task<ActionResult<List<Room>>> GetAsync()
        {
            try
            {
                List<Room> list = (List<Room>) await Repository.GetAllAsync();
                return list;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET: api/Room/5
        [HttpGet("{id}", Name = "GetRoom")]
        public async Task<ActionResult<Room>> GetAsync(int id)
        {
            Room roomDB;
            try
            {
                roomDB = await Repository.GetByIdAsync(id);
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
        public async Task<ActionResult> PostAsync([FromBody] Room room)
        {
            try
            {
                room = await Repository.CreateAsync(room);
                await Repository.SaveChangesAsync();
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
        public async Task<ActionResult> PutAsync(int id, [FromBody] Room room)
        {
            Room roomDB;
            try
            {
                roomDB = await Repository.GetByIdAsync(id);
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
                await Repository.UpdateAsync(room, id);
                await Repository.SaveChangesAsync();
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
        public async Task<ActionResult> DeleteAsync(int id)
        {
            Room roomDB;
            try
            {
                roomDB = await Repository.GetByIdAsync(id);
                if (roomDB == null)
                {
                    return NotFound(); // if resource doesn't exist, i'll return an error
                }
                roomDB = null;

                await Repository.DeleteAsync(id);
                await Repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            // return proper 204 No Content response
            return NoContent(); // success = Ok()
        }
    }
}
