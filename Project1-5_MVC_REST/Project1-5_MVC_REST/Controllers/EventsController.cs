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
    public class EventController : ControllerBase
    {
        private IEventRepository Repository { get; set; }
        private ICustomerRepository CustomerRepository { get; set; }

        public EventController(IEventRepository _respository, ICustomerRepository _customerRepository)
        {
            Repository = _respository;
            CustomerRepository = _customerRepository;
        }

        // GET: api/Event
        [HttpGet]
        public ActionResult<IList<Event>> Get()
        {
            try
            {
                List<Event> list = (List<Event>)Repository.GetAll();
                return list;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET: api/Event/5
        [HttpGet("{id}", Name = "GetEvent")]
        public ActionResult<Event> Get(int id)
        {
            Event evtDB;
            try
            {
                evtDB = Repository.GetById(id);
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            if (evtDB == null)
            {
                return NotFound(); // if resource doesn't exist, i'll return an error
            }
            return evtDB; // success = Ok()
        }

        // POST: api/Event
        [HttpPost]
        public ActionResult Post([FromBody] Event evt)
        {
            try
            {
                evt = Repository.Create(evt);
                Repository.SaveChanges();
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            // return proper 201 Created response, based on correct route for get-by-ID,
            // and return the representation of the object.
            return CreatedAtRoute("GetEvent", new { id = evt.Id }, evt);
        }

        // PUT: api/Event/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Event evt)
        {
            Event evtDB;
            try
            {
                evtDB = Repository.GetById(id);
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            if (evtDB == null)
            {
                return NotFound(); // if resource doesn't exist, i'll return an error
            }
            if (id != evtDB.Id)
            {
                return BadRequest("cannot change ID");
            }
            try
            {
                Repository.Update(evt, id);
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
            Event evtDB;
            try
            {
                evtDB = Repository.GetById(id);
                if (evtDB == null)
                {
                    return NotFound(); // if resource doesn't exist, i'll return an error
                }
                evtDB = null;

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
