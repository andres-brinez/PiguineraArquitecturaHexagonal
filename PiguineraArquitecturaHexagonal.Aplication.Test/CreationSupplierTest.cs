using Moq;
using PandemyLagacyDDD.Application.Generic;
using PiguineraArquitecturaHexagonal.Application.UseCases.Supplier;


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

    }

}

