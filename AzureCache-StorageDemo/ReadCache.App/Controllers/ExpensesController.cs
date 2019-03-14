using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadCache.App.Features.Expense;

namespace ReadCache.App.Controllers
{
    [Produces("application/json")]
    [Route("api/Expenses")]
    public class ExpensesController : Controller
    {
        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/expenses
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var expenseList = new ListExpenses.Query
            {
            };

            var result = await _mediator.Send(expenseList);

            return Ok(result);
        }
        
        // GET api/expenses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpense(Guid id)
        {
            var showExpense = new ShowExpense.Query
            {
                Id = id
            };

            var result = await _mediator.Send(showExpense);

            return Ok(result);
        }

        // POST api/expense
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateExpense.Command expense)
        {
            var result = await _mediator.Send(expense);

            return Ok(result);
        }

    }
}