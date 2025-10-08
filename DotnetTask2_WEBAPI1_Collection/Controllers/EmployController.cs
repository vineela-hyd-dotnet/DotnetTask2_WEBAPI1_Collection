using DotnetTask2_WEBAPI1_Collection.Models;
using DotnetTask2_WEBAPI1_Collection.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTask2_WEBAPI1_Collection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployController : ControllerBase
    {
        private readonly IEmployRepository _employRepository;
        public EmployController(IEmployRepository employRepository)
        {
            _employRepository = employRepository;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _employRepository.GetAll();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(employees);

        }
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById([FromRoute] int id)
        {
            var emp = _employRepository.GetById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }
        [HttpPost]

        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _employRepository.Add(employee);
            return Ok(new { message = "Employee added successfully" });
        }


        [HttpGet("dept")]
        public IActionResult GetEmployeesByDept([FromQuery] string dept)
        {
            var emp = _employRepository.GetByDept(dept);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(emp);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
            {
                
                return BadRequest("ID mismatch between URL and body.");
            }
            var existingEmployee = _employRepository.GetById(id);
            if (existingEmployee == null)
            {
                return NotFound($"Employee ID not found.");
            }
            _employRepository.Update(employee);
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(new { message = "Updated Successfully" });
        }
        [HttpPatch("{id}/{email}")]
        public IActionResult UpdateEmployeeEmail([FromRoute] int id, [FromRoute] string email)
        {
            var existingEmployee = _employRepository.GetById(id);
            if (existingEmployee == null)
            {
                return NotFound($"Employee ID not found.");
            }
            _employRepository.UpdateEmail(id, email);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(new { Message = "Email updated succesfully" });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var existingEmployee = _employRepository.GetById(id);
            if (existingEmployee == null)
            {
                return NotFound($"Employee ID not found.");
            }
            _employRepository.Delete(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(new { message = "Employee Deleted Successfully" });
        }
        [HttpHead]
        public IActionResult Head()
        {
            var count = _employRepository.GetAll().Count();
            Response.Headers.Add($"{count}", count.ToString());
            return Ok();
        }
        [HttpOptions]
        public IActionResult Options()
        {
            Response.Headers.Add("Allow", "Get,Post,Put,Patch,Delete,Head");
            return NoContent();
        }
    }
}
