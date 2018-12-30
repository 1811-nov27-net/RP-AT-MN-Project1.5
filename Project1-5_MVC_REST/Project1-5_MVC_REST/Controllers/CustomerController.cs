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
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository Repository { get; set; }

        public CustomerController(ICustomerRepository _respository)
        {
            Repository = _respository;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IList<Customer>>> GetAsync()
        {
            try
            {
                List<Customer> list = (List<Customer>) await Repository.GetAllAsync();
                return list;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<ActionResult<Customer>> GetAsync(int id)
        {
            Customer customerDB;
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

        // POST: api/Customer
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Customer customer)
        {
            try
            {
                customer = await Repository.CreateAsync(customer);
                await Repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            // return proper 201 Created response, based on correct route for get-by-ID,
            // and return the representation of the object.
            return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Customer customer)
        {
            Customer customerDB;
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
                await Repository.UpdateAsync(customer, id);
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
            Customer customerDB;
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
