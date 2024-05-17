using Microsoft.AspNetCore.Mvc;
using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands;
using PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Input;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;
using PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Output;
using PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Data;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;

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
        [Route("addBook")]
        public async Task<IActionResult> AddBook([FromBody] BookInputDTO payload, [FromServices] IInitialCommandUseCase<CreateBookCommand> useCase)
        {
            try
            {

                var providerEvent = await _repository.GetById(payload.IdProvider);
                var provideInformation = providerEvent.EventBody;

                dynamic ProviderDataToJson = Newtonsoft.Json.JsonConvert.DeserializeObject(provideInformation);
                int seniority = ProviderDataToJson.seniority;

                TypeBook typeBook = (payload.Type == "BOOK") ? TypeBook.BOOK : TypeBook.NOVEL;
                CreateBookCommand command = new CreateBookCommand(payload.IdProvider, seniority,payload.Title,payload.Quantity,typeBook,payload.OriginalPrice);
                
                var eventBook = await useCase.Execute(command);

                BookData bookDataToJson = Newtonsoft.Json.JsonConvert.DeserializeObject<BookData>(eventBook[0].EventBody);
                BookOutputDTO bookOutput = new(bookDataToJson.Title, bookDataToJson.BookType, bookDataToJson.UnitPrice, bookDataToJson.Discount, bookDataToJson.Quantity);

                return new ObjectResult(bookOutput) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");

                return new ObjectResult(ex.Message) { StatusCode = StatusCodes.Status400BadRequest };
            }
        }

        [HttpPost]
        [Route("calculateBooksPay")]
        public async Task<IActionResult> calculateBooksPay([FromBody] CalculateBookPayDto payload, [FromServices] IInitialCommandUseCase<CreateBookCommand> useCase)
        {
            try
            {

                var books = new List<Book>();
                var idBook = new List<string>();


                foreach (var informationBook in payload.InformationBook)
                {
                    idBook.Add(informationBook.IdBook);

                    var bookEvent = await _repository.GetById(informationBook.IdBook);
                    var bookEventInformation = bookEvent.EventBody;

                    dynamic BookDataToJson = Newtonsoft.Json.JsonConvert.DeserializeObject(bookEventInformation);

                    TypeBook typeBook = (BookDataToJson.BookType == "BOOK") ? TypeBook.BOOK : TypeBook.NOVEL;

                    
                    string type = BookDataToJson.BookType;
                    string title = BookDataToJson.title;
                    decimal discount = BookDataToJson.discount;
                    int quantity = BookDataToJson.quantity;
                    int unitPrice = BookDataToJson.unitPrice;

                    Book book = new Book(payload.IdSupplier, discount, title, informationBook.Quantity, typeBook, unitPrice, "hola");

                    //Console.WriteLine(book.ToString());
                    books.Add(book);
                }


                //CreateBookCommand command = new CreateBookCommand(payload.IdSupplier, seniority, payload.Title, payload.Quantity, typeBook, payload.OriginalPrice);

                //var eventBook = await useCase.Execute(command);

                //BookData bookDataToJson = Newtonsoft.Json.JsonConvert.DeserializeObject<BookData>(eventBook[0].EventBody);
                //BookOutputDTO bookOutput = new(bookDataToJson.Title, bookDataToJson.BookType, bookDataToJson.UnitPrice, bookDataToJson.Discount, bookDataToJson.Quantity);

                return new ObjectResult(idBook) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");

                return new ObjectResult(ex.Message) { StatusCode = StatusCodes.Status400BadRequest };
            }
        }
    }
}
