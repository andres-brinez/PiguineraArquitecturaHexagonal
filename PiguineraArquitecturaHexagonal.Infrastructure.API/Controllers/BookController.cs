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
                 
                CreateBookCommand command = new CreateBookCommand( payload.IdProvider,
                                                                   seniority,
                                                                   payload.Title,
                                                                   payload.Quantity,
                                                                   typeBook,
                                                                   payload.OriginalPrice
                                                                 );
                
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
        public async Task<IActionResult> calculateBooksPay([FromBody] CalculateBookPayDto payload, [FromServices] IInitialCommandUseCase<CalculatePaymentCommand> useCase)
        {
            try
            {

                var books = new List<Book>();
                var booksId = new List<string>();


                foreach (var informationBook in payload.InformationBook)
                {
                    booksId.Add(informationBook.IdBook);

                    var bookEvent = await _repository.GetById(informationBook.IdBook);
                    var bookEventInformation = bookEvent.EventBody;

                    dynamic BookDataToJson = Newtonsoft.Json.JsonConvert.DeserializeObject(bookEventInformation);

                    TypeBook typeBook = BookDataToJson.bookType == "BOOK" ? TypeBook.BOOK : TypeBook.NOVEL;

                    Book book = new Book( payload.IdSupplier,
                                          (decimal)BookDataToJson.discount,
                                          (string)BookDataToJson.title,
                                          informationBook.Quantity,
                                          typeBook,
                                          (int)BookDataToJson.unitPrice, ""
                                        );

                    books.Add(book);
                }


                CalculatePaymentCommand command = new CalculatePaymentCommand(payload.IdSupplier, booksId, books);
                
                var eventBook = await useCase.Execute(command);
                PurcheseOutputDTO bookDataToJson = Newtonsoft.Json.JsonConvert.DeserializeObject<PurcheseOutputDTO>(eventBook[0].EventBody);

                return new ObjectResult(bookDataToJson) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");

                return new ObjectResult(ex.Message) { StatusCode = StatusCodes.Status400BadRequest };
            }
        }

        [HttpPost]
        [Route("CalculateBooksBudget")]
        public async Task<IActionResult> CalculateTotalPriceBookBudget([FromBody] BudgetInputDTO payload, [FromServices] IInitialCommandUseCase<CalculatePaymentCommand> useCase)
        {
            try
            {

                var books = new List<Book>();


                foreach (var idBook in payload.IdBooks)
                {

                    var bookEvent = await _repository.GetById(idBook);

                    var bookEventInformation = bookEvent.EventBody;

                    dynamic BookDataToJson = Newtonsoft.Json.JsonConvert.DeserializeObject(bookEventInformation);

                    TypeBook typeBook = BookDataToJson.bookType == "BOOK" ? TypeBook.BOOK : TypeBook.NOVEL;

                    Book book = new Book((string)BookDataToJson.idSupplier,
                                          (decimal)BookDataToJson.discount,
                                          (string)BookDataToJson.title,
                                          1,
                                          typeBook,
                                          (int)BookDataToJson.unitPrice, ""
                                        );

                    books.Add(book);
                }


                //CalculatePaymentCommand command = new CalculatePaymentCommand(payload.IdSupplier, booksId, books);

                //var eventBook = await useCase.Execute(command);
                //PurcheseOutputDTO bookDataToJson = Newtonsoft.Json.JsonConvert.DeserializeObject<PurcheseOutputDTO>(eventBook[0].EventBody);

                return new ObjectResult(books.Select(book => book.ToString())) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");

                return new ObjectResult(ex.Message) { StatusCode = StatusCodes.Status400BadRequest };
            }
        }

    }
}
