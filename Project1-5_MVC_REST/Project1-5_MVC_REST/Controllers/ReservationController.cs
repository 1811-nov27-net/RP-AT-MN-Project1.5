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
        public ActionResult<IList<Reservation>> Get()
        {
            try
            {
                List<Reservation> list = (List<Reservation>)Repository.GetAll();
                return list;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET: api/Reservation/5
        [HttpGet("{id}", Name = "GetReservation")]
        public ActionResult<Reservation> Get(int id)
        {
            Reservation reservationDB;
            try
            {
                reservationDB = Repository.GetById(id);
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
        public ActionResult Post([FromBody] Reservation reservation)
        {
            try
            {
                //Need this to calculate Cost, based on Room
                reservation.Room = RoomRepository.GetById(reservation.RoomId);

                reservation.calculateCost();
                reservation = Repository.Create(reservation);
                Repository.SaveChanges();
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
        public ActionResult Put(int id, [FromBody] Reservation reservation)
        {
            Reservation reservationDB;
            try
            {
                reservationDB = Repository.GetById(id);
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
                reservation.Room = RoomRepository.GetById(reservation.RoomId);

                reservation.calculateCost();
                Repository.Update(reservation, id);
                Repository.SaveChanges();
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
        public ActionResult Delete(int id)
        {
            Reservation reservationDB;
            try
            {
                reservationDB = Repository.GetById(id);
                if (reservationDB == null)
                {
                    return NotFound(); // if resource doesn't exist, i'll return an error
                }
                reservationDB = null;

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
    }
}
