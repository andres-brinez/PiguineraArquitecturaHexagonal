using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands;
using Newtonsoft.Json;
using PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Input;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;

namespace PiguineraArquitecturaHexagonal.Infrastructure.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {

        private readonly IEventsRepository _repository;

        public BookController(IEventsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("AddBook")]
        public async Task<IActionResult> CreateCity([FromBody] BookInputDTO payload, [FromServices] IInitialCommandUseCase<CreateBookCommand> useCase)
        {
            try
            {

                TypeBook typeBook;

                var result = await _repository.GetById(payload.IdProvider);


                if (payload.Type == "BOOK")
                {
                    typeBook = TypeBook.BOOK;
                }
                else
                {
                    typeBook = TypeBook.NOVEL;
                }

                // Cadena de texto con los datos
                var eventBody = result.EventBody;

                dynamic userDataJson = Newtonsoft.Json.JsonConvert.DeserializeObject(eventBody);
                int seniority = userDataJson.seniority;

                CreateBookCommand command = new CreateBookCommand(payload.IdProvider, seniority,payload.Title,payload.Quantity,typeBook,payload.OriginalPrice);
                var @event = await useCase.Execute(command);

                return new ObjectResult(@event) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");

                return new ObjectResult(ex.Message) { StatusCode = StatusCodes.Status400BadRequest };
            }
        }
    }
}
