using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1_5_DataAccess.Repositories;
using Project1_5_Library;
using Project1_5_Library.RepoInterfaces;

namespace Project1_5_MVC_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerEventsController : Controller
    {
        private IEventCustomerRepository EventRepository { get; set; }

        public CustomerEventsController(IEventCustomerRepository _eventRepository)
        {
            EventRepository = _eventRepository;
        }

        //Get All Events by customer
        // GET: api/CustomerEvents/5
        [HttpGet("{id}", Name = "GetAll")]
        public async Task<ActionResult<List<EventCustomer>>> GetAsync(int id)
       {
            try
            {
                List<EventCustomer> events = (List<EventCustomer>)await EventRepository.GetByCustomerIdAsync(id);

                foreach(var item in events)
                {
                    item.Event.EventsCustomers = null;
                }

                return events;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}