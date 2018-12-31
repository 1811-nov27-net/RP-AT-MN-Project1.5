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
    public class CheckoutController : ControllerBase
    {
        private IReservationRepository Repository { get; set; }
        private IEventCustomerRepository EventRepository { get; set; }

        public CheckoutController(IReservationRepository _repo, IEventCustomerRepository _eventRepository)
        {
            Repository      = _repo;
            EventRepository = _eventRepository;
        }

        // GET: api/Checkout/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<decimal>> GetAsync(int id)
        {
            try
            {
                decimal cost = 0;

                Reservation reservation = await Repository.GetByIdAsync(id);

                if (reservation == null)
                {
                    return NotFound(); // if resource doesn't exist, i'll return an error
                }

                cost += reservation.TotalCost;

                List<EventCustomer> events = (List<EventCustomer>) await EventRepository.GetByCustomerIdAsync(reservation.CustomerId);

                foreach(EventCustomer evt in events)
                {
                    if(evt.Paid == false)
                    {
                        cost += evt.Event.Cost;
                    }
                }

                return cost;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // PUT: api/ApiWithActions/5
        [HttpPut("{id}")]
        public async Task<ActionResult> CheckoutAsync(int id)
        {
            Reservation reservationDB;
            try
            {
                reservationDB = await Repository.GetByIdAsync(id);
                
                if (reservationDB == null)
                {
                    return NotFound(); // if resource doesn't exist, i'll return an error
                }

                reservationDB.Paid = true;
                await Repository.UpdateAsync(reservationDB, reservationDB.Id);
                await Repository.SaveChangesAsync();

                List<EventCustomer> events = (List<EventCustomer>)await EventRepository.GetByCustomerIdAsync(reservationDB.CustomerId);
                foreach(var item in events)
                {
                    item.Paid = true;
                    await EventRepository.UpdateAsync(item, item.Id);
                    await EventRepository.SaveChangesAsync();
                }

                // return proper 204 No Content response
                return NoContent(); // success = Ok()
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
