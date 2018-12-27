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
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository Repository { get; set; }

        public EmployeeController(IEmployeeRepository _respository)
        {
            Repository = _respository;
        }

        // GET: api/Employee
        [HttpGet]
        public ActionResult<IList<Employee>> Get()
        {
            try
            {
                List<Employee> list = (List<Employee>)Repository.GetAll();
                return list;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "GetEmployee")]
        public ActionResult<Employee> Get(int id)
        {
            Employee employeeDB;
            try
            {
                employeeDB = Repository.GetById(id);
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            if (employeeDB == null)
            {
                return NotFound(); // if resource doesn't exist, i'll return an error
            }
            return employeeDB; // success = Ok()
        }

        // POST: api/Employee
        [HttpPost]
        public ActionResult Post([FromBody] Employee employee)
        {
            try
            {
                employee = Repository.Create(employee);
                Repository.SaveChanges();
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            // return proper 201 Created response, based on correct route for get-by-ID,
            // and return the representation of the object.
            return CreatedAtRoute("GetEmployee", new { id = employee.Id }, employee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Employee employee)
        {
            Employee employeeDB;
            try
            {
                employeeDB = Repository.GetById(id);
            }
            catch (Exception ex)
            {
                // internal server error
                return StatusCode(500, ex);
            }
            if (employeeDB == null)
            {
                return NotFound(); // if resource doesn't exist, i'll return an error
            }
            if (id != employeeDB.Id)
            {
                return BadRequest("cannot change ID");
            }
            try
            {
                Repository.Update(employee, id);
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
            Employee employeeDB;
            try
            {
                employeeDB = Repository.GetById(id);
                if (employeeDB == null)
                {
                    return NotFound(); // if resource doesn't exist, i'll return an error
                }
                employeeDB = null;

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
