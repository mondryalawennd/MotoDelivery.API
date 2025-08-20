using Xunit;
using System.Text.Json;
using System.Net;
using FluentAssertions;
using MotoDelivery.API;
using Microsoft.AspNetCore.Mvc.Testing;
using MotoDelivery.API.Features.Entregador.CreateEntregador;
using System.Net.Http.Json;
using MotoDelivery.Application.Entregador.UploadCNH;
using MassTransit;

namespace MotoDelivery.Tests.Integration.Controllers
{
    public class EntregadorControllerTests : IClassFixture<TestWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public EntregadorControllerTests()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
            var factory = new TestWebApplicationFactory();
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostEntregador_DeveRetornarCriado_QuandoDadosForemValidos()
        {
            // Arrange
            var request = new CreateEntregadorRequest
            {
                Identificador = "entregador12",
                Nome = "Jonas Lucas Maia",
                CNPJ = "45739121000198",
                NumeroCNH = "05732172392",
                TipoCNH = "A",
                DataNascimento = "08/01/1992"
            };

            var response = await _client.PostAsJsonAsync("/api/Entregador", request);

            //para debug
            //if (!response.IsSuccessStatusCode)
            //{
            //    var errorContent = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine(errorContent);
            //}

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var responseData = await response.Content.ReadFromJsonAsync<CreateEntregadorResponse>();
            Assert.NotNull(responseData);
            Assert.Equal(request.Nome, responseData.Nome);
        }

        [Fact]
        public async Task PostUploadCNH_DeveRetornarOk_QuandoArquivoForValido()
        {
            // Arrange
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent("entregador01"), "Identificador");

            var fileBytes = new byte[] { 0x1, 0x2 }; // cabeçalho básico PNG
            var fileContent = new ByteArrayContent(fileBytes);
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            formData.Add(fileContent, "ImagemCNH", "cnh.png");

            // Act
            var response = await _client.PostAsync("/api/entregador/upload/cnh", formData);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Erro retornado pelo servidor: " + errorContent);
            }
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var result = await response.Content.ReadFromJsonAsync<UploadCNHResult>();
            Assert.NotNull(result);
        }
    }
}