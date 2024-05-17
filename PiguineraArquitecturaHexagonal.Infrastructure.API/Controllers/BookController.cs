using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands;
using Newtonsoft.Json;
using PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Input;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;
using PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Output;
using MongoDB.Bson;
using PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Data;

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



                var result = await _repository.GetById(payload.IdProvider);
                var eventBody = result.EventBody;

                dynamic userDataJson = Newtonsoft.Json.JsonConvert.DeserializeObject(eventBody);
                int seniority = userDataJson.seniority;

                TypeBook typeBook = (payload.Type == "BOOK") ? TypeBook.BOOK : TypeBook.NOVEL;
                CreateBookCommand command = new CreateBookCommand(payload.IdProvider, seniority,payload.Title,payload.Quantity,typeBook,payload.OriginalPrice);
                
                var @event = await useCase.Execute(command);

                BookData bookDataJson = Newtonsoft.Json.JsonConvert.DeserializeObject<BookData>(@event[0].EventBody);
                BookOutputDTO bookOutput = new(bookDataJson.Title, bookDataJson.BookType, bookDataJson.UnitPrice, bookDataJson.Discount, bookDataJson.Quantity);

                return new ObjectResult(bookOutput) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");

                return new ObjectResult(ex.Message) { StatusCode = StatusCodes.Status400BadRequest };
            }
        }
    }
}
