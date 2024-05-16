using Microsoft.AspNetCore.Mvc;
using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Api.DataTransferObject;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Commands;

namespace PiguineraArquitecturaHexagonal.Infrastructure.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : Controller
    {
        [HttpPost]
        [Route("CreayeSuppler")]
        public async Task<IActionResult> CreateCity([FromBody] SupplierCreate payload, [FromServices] IInitialCommandUseCase<CreateSupplierCommnad> useCase)
        {
            try
            {

                CreateSupplierCommnad command = new CreateSupplierCommnad(payload.Email,payload.Password);
                Console.WriteLine(payload.Email);
                var result = await useCase.Execute(command);

                return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");

                return new ObjectResult(ex.Message) { StatusCode = StatusCodes.Status400BadRequest };
            }
        }
    }
}
