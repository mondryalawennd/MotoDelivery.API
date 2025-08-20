using AutoMapper;
using Moq;
using MotoDelivery.Application.Moto.GetMoto;
using MotoDelivery.Domain.Repositories;
using Xunit;
using Motos = MotoDelivery.Domain.Entities.Moto;
using FluentAssertions;

namespace MotoDelivery.Test.Unit.Application.Moto
{
    public class GetMotoHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMotoRepository> _repositorioMock;      

        public GetMotoHandlerTests()
        {
            _repositorioMock = new Mock<IMotoRepository>();

            var config = new MapperConfiguration(cfg => {cfg.CreateMap<Motos, GetMotoResult>(); });

            _mapper = config.CreateMapper();
        }

        [Fact(DisplayName = "Deve criar uma moto com sucesso")]
        public async Task Handle_CriaMoto_ERetornaMoto()
        {
            // Arrange
            var moto = Motos.Criar("moto08", "Honda", 2023, "ABC1234");

            _repositorioMock.Setup(r => r.ObterPorIdAsync(It.IsAny<string>())).ReturnsAsync(moto);

            var handler = new GetMotoHandler(_repositorioMock.Object, _mapper);
            var command = new GetMotoCommand
            {
                Identificador = moto.Identificador
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Placa.Should().Be("ABC1234");
        }
    }
}
