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
        public ActionResult<IList<EventCustomer>> Get()
        {
            try
            {
                List<EventCustomer> list = (List<EventCustomer>)Repository.GetAll();
                return list;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET: api/EventCustomer/5
        [HttpGet("{id}", Name = "GetEventCustomer")]
        public ActionResult<EventCustomer> Get(int id)
        {
            EventCustomer customerDB;
            try
            {
                customerDB = Repository.GetById(id);
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
        public ActionResult Post([FromBody] EventCustomer customer)
        {
            try
            {
                customer = Repository.Create(customer);
                Repository.SaveChanges();
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
        public ActionResult Put(int id, [FromBody] EventCustomer customer)
        {
            EventCustomer customerDB;
            try
            {
                customerDB = Repository.GetById(id);
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
                Repository.Update(customer, id);
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
            EventCustomer customerDB;
            try
            {
                customerDB = Repository.GetById(id);
                if (customerDB == null)
                {
                    return NotFound(); // if resource doesn't exist, i'll return an error
                }
                customerDB = null;

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
