using Microsoft.AspNetCore.Mvc;
using MySchool.Domain.Queries;
using MyStockSys.infra.Data.Repositories.Transactions;
using MyStockSys.Ui.Api.Controllers.Base;
using System;
using System.Threading.Tasks;

namespace MyStockSys.Ui.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PraductController : CommonController
    {
        public PraductController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PraductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PraductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
