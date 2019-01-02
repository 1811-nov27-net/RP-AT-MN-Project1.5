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
    public class EventCustomerController : ControllerBase
    {
        private IEventCustomerRepository Repository { get; set; }

        public EventCustomerController(IEventCustomerRepository _respository)
        {
            Repository = _respository;
        }

        // GET: api/EventCustomer
        [HttpGet]
        public async Task<ActionResult<IList<EventCustomer>>> GetAsync()
        {
            try
            {
                List<EventCustomer> list = (List<EventCustomer>) await Repository.GetAllAsync();
                return list;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET: api/EventCustomer/5
        [HttpGet("{id}", Name = "GetEventCustomer")]
        public async Task<ActionResult<EventCustomer>> GetAsync(int id)
        {
            EventCustomer customerDB;
            try
            {
                customerDB = await Repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            if (customerDB == null)
            {
                return NotFound(); // if resource doesn't exist, i'll return an error
            }
            return customerDB; // success = Ok()
        }

        // POST: api/EventCustomer
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] EventCustomer customer)
        {
            try
            {
                customer = await Repository.CreateAsync(customer);
                Repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            // return proper 201 Created response, based on correct route for get-by-ID,
            // and return the representation of the object.
            return CreatedAtRoute("GetEventCustomer", new { id = customer.Id }, customer);
        }

        // PUT: api/EventCustomer/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] EventCustomer customer)
        {
            EventCustomer customerDB;
            try
            {
                customerDB = await Repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            if (customerDB == null)
            {
                return NotFound(); // if resource doesn't exist, i'll return an error
            }
            if (id != customerDB.Id)
            {
                return BadRequest("cannot change ID");
            }
            try
            {
                Repository.UpdateAsync(customer, id);
                Repository.SaveChangesAsync();
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
            EventCustomer customerDB;
            try
            {
                customerDB = await Repository.GetByIdAsync(id);
                if (customerDB == null)
                {
                    return NotFound(); // if resource doesn't exist, i'll return an error
                }
                customerDB = null;

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
