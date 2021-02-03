using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using MySchool.Domain.Queries;
using MyStockSys.Domain.Commands.InventoryControl;
using MyStockSys.infra.Data.Repositories.Transactions;
using MyStockSys.Ui.Api.Controllers.Base;
using MyStockSys.Domain.Commands;
using MyStockSys.Domain.Handlers;

namespace MyStockSys.Ui.Api.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryControlController : CommonController
    {
        public InventoryControlController(IUnitOfWork unitOfWork) : base(unitOfWork) {}

        // GET: api/<PraductController>
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] InventoryControlQueries inventoryControlQueries)
        {
            return Ok(await inventoryControlQueries.GetAll());
        }

        // GET api/<PraductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, [FromServices] ProductQueries productQueries)
        {
            return Ok(await productQueries.Get(Guid.Parse(id)));
        }

        // POST api/<PraductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddInventoryControlCommand command, [FromServices] InventoryControlHandler handler)
        {
            return ResponseAsync(handler.Handle(command).Result as CommandResult);
        }
    }
}
