using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.CachedStorage.Entities.DataWriter.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Azure.CachedStorage.Demo.Controllers
{
    [Produces("application/json")]
    [Route("api/Expenses")]
    public class ExpensesController : Controller
    {
        private IRepositoryWrapper _repository;

        public ExpensesController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // GET: api/Expenses
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var expenses = await _repository.Expense.GetAllExpensesAsync();

                return Ok(expenses);
            }
            catch (Exception ex)
            {
               // _logger.LogError($"Some error in the GetAllOwners method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Expenses/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Expenses
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Expenses/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
