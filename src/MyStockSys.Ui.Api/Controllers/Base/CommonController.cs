using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyStockSys.Domain.Commands;
using MyStockSys.infra.Data.Repositories.Transactions;
using System;

namespace MyStockSys.Ui.Api.Controllers.Base
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult ResponseAsync(CommandResult commandResult)
        {
            if (commandResult.Success)
            {
                try
                {
                    _unitOfWork.SaveChanges();

                    return Ok(commandResult);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return Ok(commandResult);
            }
        }

        public IActionResult ResponseExceptionAsync(Exception ex)
        {
            return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
        }
    }
}
