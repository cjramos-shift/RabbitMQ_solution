using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using RabbitMQ.Client;
using TestPublisher.Adapter.Secondary;
using TestPublisher.Core.Abstracts;
using TestPublisher.Core.Ports;
using TestPublisher.Core.Services;
using TestPublisher.Core.ValueObjects;

namespace TestProject.UnitTests
{
    public class ProgramUnitTest
    {
        static ProgramUnitTest()
        {
            CriarConexaoAsync_DeveRetornarConexaoValida();
            PublicarMensagemIndividualmenteAsync_DevePubricarMensagens();
        }

        [Fact]
        static async Task CriarConexaoAsync_DeveRetornarConexaoValida()
        {
            // Arrange
            var factoryVo = new FactoryVo();
            IFactory factory = new FactoryService(factoryVo);

            // Act
            var conexao = await factory.CriarConexaoAsync();

            // Assert
            Assert.NotNull(conexao);
            Assert.True(conexao.IsOpen);
        }

        [Fact]
        static async Task PublicarMensagemIndividualmenteAsync_DevePubricarMensagens()
        {
            // Arrange
            var mockFactory = new Mock<IFactory>();
            var mockPublicarService = new Mock<IPublicarMensagensIndividualmenteService>();

            var publicarMensagens = new PublicarMensagemIndividualmente(mockFactory.Object, mockPublicarService.Object);
            var channelOpts = new CreateChannelOptions(
                publisherConfirmationsEnabled: true,
                publisherConfirmationTrackingEnabled: true,
                outstandingPublisherConfirmationsRateLimiter: new ThrottlingRateLimiter(Constantes.MAX_OUTSTANDING_CONFIRMS)
            );
            var props = new BasicProperties { Persistent = true };

            // Act
            await publicarMensagens.PublicarMensagemIndividualmenteAsync(channelOpts, props);

            // Assert
            mockPublicarService.Verify(x => x.PublicarMensagemIndividualmenteAsync(mockFactory.Object, channelOpts, props), Times.Once);

            // Com FluentAssertions
            mockFactory.Object.Should().NotBeNull();
            mockPublicarService.Object.Should().NotBeNull();
        }
    }
}
