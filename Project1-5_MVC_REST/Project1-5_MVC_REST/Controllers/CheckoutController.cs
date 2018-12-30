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

        // GET: api/Checkout/5/3
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<decimal> Get(int id)
        {
            try
            {
                decimal cost = 0;

                Reservation reservation = Repository.GetById(id);

                if (reservation == null)
                {
                    return NotFound(); // if resource doesn't exist, i'll return an error
                }

                cost += reservation.TotalCost;

                List<EventCustomer> events = (List<EventCustomer>)EventRepository.GetByCustomerId(reservation.CustomerId);

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
    }
}
