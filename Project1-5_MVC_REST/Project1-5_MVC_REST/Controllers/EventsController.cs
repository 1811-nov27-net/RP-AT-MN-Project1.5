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
        public async Task<ActionResult<IList<Event>>> GetAsync()
        {
            try
            {
                List<Event> list = (List<Event>) await Repository.GetAllAsync();
                return list;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET: api/Event/5
        [HttpGet("{id}", Name = "GetEvent")]
        public async Task<ActionResult<Event>> GetAsync(int id)
        {
            Event evtDB;
            try
            {
                evtDB = await Repository.GetByIdAsync(id);
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
        public async Task<ActionResult> PostAsync([FromBody] Event evt)
        {
            try
            {
                evt = await Repository.CreateAsync(evt);
                await Repository.SaveChangesAsync();
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
        public async Task<ActionResult> PutAsync(int id, [FromBody] Event evt)
        {
            Event evtDB;
            try
            {
                evtDB = await Repository.GetByIdAsync(id);
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
                await Repository.UpdateAsync(evt, id);
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
            Event evtDB;
            try
            {
                evtDB = await Repository.GetByIdAsync(id);
                if (evtDB == null)
                {
                    return NotFound(); // if resource doesn't exist, i'll return an error
                }
                evtDB = null;

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
