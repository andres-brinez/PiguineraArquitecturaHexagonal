﻿using Microsoft.AspNetCore.Mvc;
using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands;
using PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Input;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;
using PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Output;
using PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Data;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;
using Newtonsoft.Json;


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
                CreateBookCommand command = new CreateBookCommand(payload.IdProvider,
                                                                   (string)ProviderDataToJson.email,
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

        [HttpGet("GetAllBooks")]

        public async Task<ActionResult> GetAllBooks()
        {
            var events = await _repository.GetAllByType("BOOK_CREATED");
            var books = new List<BookInformation>();


            if (events == null || !events.Any())
            {
                return NotFound($"No events found with type '{"BOOK_CREATED"}'");
            }

            foreach (var eventBook in events)
            {

                var bookEventInformation = eventBook.EventBody;
                Console.WriteLine(bookEventInformation);


                dynamic BookDataToJson = Newtonsoft.Json.JsonConvert.DeserializeObject(bookEventInformation);

                BookInformation book = new BookInformation(eventBook.UUID,
                                      (string)BookDataToJson.emailSupplier,
                                      (string)BookDataToJson.title,
                                      (string)BookDataToJson.bookType,
                                      (int)BookDataToJson.unitPrice,
                                      (float)BookDataToJson.discount

                                    );

                Console.WriteLine(book.ToString());
                books.Add(book);

            }

            AllBookDTO output = new AllBookDTO(books);
            Console.WriteLine(output.Books[0].ToString());


            return Ok(output);
        }

        [HttpPost]
        [Route("calculateBooksPay")]
        public async Task<IActionResult> calculateBooksPay([FromBody] CalculateBooksPayInputDto payload, [FromServices] IInitialCommandUseCase<CalculatePaymentCommand> useCase)
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

                    Book book = new Book(payload.IdSupplier,
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
        public async Task<IActionResult> CalculateTotalPriceBookBudget([FromBody] BudgetInputDTO payload, [FromServices] IInitialCommandUseCase<CalculateBudgetCommand> useCase)
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


                CalculateBudgetCommand command = new CalculateBudgetCommand(payload.IdSupplier, books, payload.Budget);

                var eventBook = await useCase.Execute(command);

                BudgetOutputDTO bookDataToJson = Newtonsoft.Json.JsonConvert.DeserializeObject<BudgetOutputDTO>(eventBook[0].EventBody);

                return new ObjectResult(bookDataToJson) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");

                return new ObjectResult(ex.Message) { StatusCode = StatusCodes.Status400BadRequest };
            }
        }

        [HttpPost]
        [Route("calculateBooksQuotes")]
        public async Task<IActionResult> calculateBooksQuotes([FromBody] CalculateBooksQuotesInputDto payload, [FromServices] IInitialCommandUseCase<CalculateQuoteCommand> useCase)
        {
            try
            {

                List<List<Book>> groupBooks = new List<List<Book>>();


                foreach (var groupBooksInformation in payload.InformationBooks)
                {
                    List<Book> books = new List<Book>();

                    foreach (var informationBook in groupBooksInformation)
                    {
                        var bookEvent = await _repository.GetById(informationBook.IdBook);

                        var bookEventInformation = bookEvent.EventBody;

                        dynamic BookDataToJson = Newtonsoft.Json.JsonConvert.DeserializeObject(bookEventInformation);

                        TypeBook typeBook = BookDataToJson.bookType == "BOOK" ? TypeBook.BOOK : TypeBook.NOVEL;

                        Book book = new Book(payload.IdSupplier,
                                              (decimal)BookDataToJson.discount,
                                              (string)BookDataToJson.title,
                                              informationBook.Quantity,
                                              typeBook,
                                              (int)BookDataToJson.unitPrice, ""
                                            );

                        books.Add(book);
                    }
                    groupBooks.Add(books);

                }

                CalculateQuoteCommand command = new CalculateQuoteCommand(payload.IdSupplier, groupBooks);

                var eventBook = await useCase.Execute(command);

                QuotesOutputDTO quotesDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<QuotesOutputDTO>(eventBook[0].EventBody);

                return new ObjectResult(quotesDTO) { StatusCode = StatusCodes.Status200OK };
            }
            catch (JsonSerializationException ex)
            {
                return new ObjectResult($"Deserialization error: {ex.Message}") { StatusCode = StatusCodes.Status400BadRequest };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return new ObjectResult(ex.Message) { StatusCode = StatusCodes.Status400BadRequest };
            }
        }


    }
}
