using Microsoft.AspNetCore.Mvc;
using MySchool.Domain.Queries;
using MyStockSys.Domain.Commands;
using MyStockSys.Domain.Commands.Product;
using MyStockSys.Domain.Handlers;
using MyStockSys.infra.Data.Repositories.Transactions;
using MyStockSys.Ui.Api.Controllers.Base;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace MyStockSys.Ui.Api.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class PraductController : CommonController
    {
        public PraductController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // GET: api/<PraductController>
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] ProductQueries productQueries)
        {
            return Ok(await productQueries.GetAll());
        }

        // GET api/<PraductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, [FromServices] ProductQueries productQueries)
        {
            return Ok(await productQueries.Get(Guid.Parse(id)));
        }

        // POST api/<PraductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductCommand command, [FromServices] ProductHandler handler)
        {
            return ResponseAsync(handler.Handle(command).Result as CommandResult);
        }

        // PUT api/<PraductController>/5
        [HttpPatch]
        [Route("UpdateName")]
        public async Task<IActionResult> UpdateName([FromBody] UpdateProductNameCommand command, [FromServices] ProductHandler handler)
        {
          return ResponseAsync(handler.Handle(command).Result as CommandResult);
        }

        // PUT api/<PraductController>/5
        [HttpPatch]
        [Route("UpdatePrice")]
        public async Task<IActionResult> UpdatePrice([FromBody] UpdateProductPriceCommand command, [FromServices] ProductHandler handler)
        {
           return ResponseAsync(handler.Handle(command).Result as CommandResult);
        }

        // DELETE api/<PraductController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommand command, [FromServices] ProductHandler handler)
        {
            return ResponseAsync(handler.Handle(command).Result as CommandResult);
        }
    }
}