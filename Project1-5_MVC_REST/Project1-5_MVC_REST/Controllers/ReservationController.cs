using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1_5_Library;
using Project1_5_Library.RepoInterfaces;
using Project1_5_Library.Exceptions;

namespace Project1_5_MVC_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IReservationRepository Repository { get; set; }
        private IRoomRepository RoomRepository { get; set; }

        public ReservationController(IReservationRepository _respository, IRoomRepository _roomRepository)
        {
            Repository = _respository;
            RoomRepository = _roomRepository;
        }

        // GET: api/Reservation
        [HttpGet]
        public async Task<ActionResult<IList<Reservation>>> GetAsync()
        {
            try
            {
                List<Reservation> list = (List<Reservation>)await Repository.GetAllAsync();
                return list;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET: api/Reservation/5
        [HttpGet("{id}", Name = "GetReservation")]
        public async Task<ActionResult<Reservation>> GetAsync(int id)
        {
            Reservation reservationDB;
            try
            {
                reservationDB = await Repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            if (reservationDB == null)
            {
                return NotFound(); // if resource doesn't exist, i'll return an error
            }
            return reservationDB; // success = Ok()
        }

        // POST: api/Reservation
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Reservation reservation)
        {
            try
            {
                //Need this to calculate Cost, based on Room
                reservation.Room = await RoomRepository.GetByIdAsync(reservation.RoomId);

                reservation.calculateCost();
                reservation = await Repository.CreateAsync(reservation);
                await Repository.SaveChangesAsync();
            }
            catch (SameDateException ex)
            {
                return BadRequest(ex);
            }
            catch (EndDateBeforeStartDateException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            // return proper 201 Created response, based on correct route for get-by-ID,
            // and return the representation of the object.
            return CreatedAtRoute("GetReservation", new { id = reservation.Id }, reservation);
        }

        // PUT: api/Reservation/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Reservation reservation)
        {
            Reservation reservationDB;
            try
            {
                reservationDB = await Repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            if (reservationDB == null)
            {
                return NotFound(); // if resource doesn't exist, i'll return an error
            }
            if (id != reservationDB.Id)
            {
                return BadRequest("cannot change ID");
            }
            try
            {
                //Need this to calculate Cost, based on Room
                reservation.Room = await RoomRepository.GetByIdAsync(reservation.RoomId);

                reservation.calculateCost();
                await Repository.UpdateAsync(reservation, id);
                await Repository.SaveChangesAsync();
            }
            catch (SameDateException ex)
            {
                return BadRequest(ex);
            }
            catch (EndDateBeforeStartDateException ex)
            {
                return BadRequest(ex);
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
            Reservation reservationDB;
            try
            {
                reservationDB = await Repository.GetByIdAsync(id);
                if (reservationDB == null)
                {
                    return NotFound(); // if resource doesn't exist, i'll return an error
                }
                reservationDB = null;

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
