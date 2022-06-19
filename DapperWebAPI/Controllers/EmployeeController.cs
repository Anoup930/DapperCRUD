using Autofac;
using DapperWebAPI.Models;
using DapperWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService employeeService;
        private readonly ILifetimeScope _scope;
    
        public EmployeeController(EmployeeService _employeeService, ILifetimeScope scope) 
        {
            employeeService= _employeeService;
            _scope= scope;
        }

        //Get ALL
        [HttpGet]
        [Route("Get")]
        public IEnumerable<Employee> GetAll() 
        {
            return employeeService.GetAll();
        }

        //Get By Id
        [HttpGet]
        [Route("Get/{id}")]
        public Employee GetById(int id) 
        {
            return employeeService.GetById(id);
        
        }

        //INSERT
        [HttpPost]
        public void Post([FromBody] Employee employee) 
        { 
            if(ModelState.IsValid)
                employeeService.Add(employee);
        }

        //UPDATE
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee) 
        {
            employee.EmployeeId = id;
           
            if(ModelState.IsValid)
                employeeService.Update(employee);
        }

        //DELETE
        [HttpDelete]
        public void Delete(int id) 
        {
            employeeService.Delete(id);
        }
    }
}
