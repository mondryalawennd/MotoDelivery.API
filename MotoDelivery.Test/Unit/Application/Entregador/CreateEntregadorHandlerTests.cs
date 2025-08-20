using AutoMapper;
using Moq;
using MotoDelivery.Application.Entregador.CreateEntregador;
using Entregador_ = MotoDelivery.Domain.Entities.Entregador;
using MotoDelivery.Domain.Repositories;
using Xunit;
using FluentAssertions;

namespace MotoDelivery.Test.Unit.Application.Entregador
{
    public class CreateEntregadorHandlerTests
    {
        private readonly Mock<IEntregadorRepository> _entregadorRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CreateEntregadorHandler _handler;

        public CreateEntregadorHandlerTests()
        {
            _entregadorRepositoryMock = new Mock<IEntregadorRepository>();
            _mapperMock = new Mock<IMapper>();

            _handler = new CreateEntregadorHandler(_entregadorRepositoryMock.Object);
        }

        [Fact(DisplayName = "Deve criar um entregador com sucesso")]
        public async Task Handle_DeveCriarEntregador_QuandoDadosValidos()
        {
            // Arrange
            var command = new CreateEntregadorCommand
            {
                Identificador = "entregador18",
                Nome = "Lucas Silva",
                CNPJ = "13455678005595",
                DataNascimento = new DateTime(1990, 1, 1),
                ImagemCNHUrl = string.Empty,
                NumeroCNH = "1234589040",
                TipoCNH = "A"
            };

            var entregador = new Entregador_(command.Identificador, command.Nome, command.CNPJ, command.DataNascimento, command.NumeroCNH, command.TipoCNH);
           
            var resultEsperado = new CreateEntregadorResult
            {
                Identificador = entregador.Identificador,
                Nome = entregador.Nome,
                Mensagem = "Entregador cadastrado com sucesso!"
            };

            _entregadorRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Entregador_>())).Returns(Task.CompletedTask);

            _mapperMock.Setup(m => m.Map<CreateEntregadorResult>(It.IsAny<Entregador_>())).Returns(resultEsperado);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Nome.Should().Be(command.Nome);
            result.Identificador.Should().Be(command.Identificador);
            result.Mensagem.Should().Be("Entregador cadastrado com sucesso!");

            _entregadorRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Entregador_>()), Times.Once);
        }

    }
}