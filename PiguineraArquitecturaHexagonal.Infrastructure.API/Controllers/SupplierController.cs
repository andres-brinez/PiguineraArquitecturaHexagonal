using Microsoft.AspNetCore.Mvc;
using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Commands;
using PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Input;

namespace PiguineraArquitecturaHexagonal.Infrastructure.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : Controller
    {
        [HttpPost]
        [Route("CreateSuppler")]
        public async Task<IActionResult> CreateCity([FromBody] SupplierCreate payload, [FromServices] IInitialCommandUseCase<CreateSupplierCommnad> useCase)
        {
            try
            {

                CreateSupplierCommnad command = new CreateSupplierCommnad(payload.Email,payload.Password);

                var eventResult = await useCase.Execute(command);

                dynamic userRegister = Newtonsoft.Json.JsonConvert.DeserializeObject(eventResult[0].EventBody);

                if(userRegister.registerDate!=null) {
                    return new ObjectResult($"Usuario {userRegister.email} registrado correctamente") { StatusCode = StatusCodes.Status200OK };
                }


                return new ObjectResult("Error al registrar el usuario") { StatusCode = StatusCodes.Status400BadRequest };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");

                return new ObjectResult(ex.Message) { StatusCode = StatusCodes.Status400BadRequest };
            }
        }
    }
}
