using Moq;
using PandemyLagacyDDD.Application.Generic;
using PiguineraArquitecturaHexagonal.Application.UseCases.Supplier;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Commands;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Events;


namespace PiguineraArquitecturaHexagonal.Aplication.Test
{
    public class CreationSupplierTest
    {
        private readonly Mock<IEventsRepository> _mockEventsRepository;
        private readonly CreateSupplierUseCase _useCase;

        public CreationSupplierTest()
        {
            _mockEventsRepository = new Mock<IEventsRepository>();
            _useCase = new CreateSupplierUseCase(_mockEventsRepository.Object);
        }

        [Fact]
        public async void CreationSupplierSucessTest()
        {
            CreatedSupplier createCityExpected = new CreatedSupplier("brinezlopez08@gmail.com", "123");
            createCityExpected.AggregateId = "hola";

            CreateSupplierCommnad createCityCommand = new CreateSupplierCommnad("brinezlopez08@gmail.com", "123");

            //_mockEventsRepository.Setup(repo => repo.Save(It.IsAny<DomainEvent>()))
            //                     .Returns((createCityExpected));


            var result = await _useCase.Execute(createCityCommand);

            Assert.NotEmpty( result);
            Assert.IsType<CreatedSupplier>( result);
            Assert.Equivalent(1, result.Count);

            //_mockEventsRepository.Verify(rep=>rep
            //            .Save(It.IsAny<DomainEvent>()),Times.Once);

            var result2 = (CreatedSupplier)result[0];


            Assert.NotNull(result2.AggregateId);
            Assert.Equivalent(createCityExpected.Email, result2.Email);
           

        }
    }
}


