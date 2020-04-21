using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;

namespace Yoti.Auth.Sandbox.Tests
{
    internal class HttpMock
    {
        public static Mock<HttpMessageHandler> SetupMockMessageHandler(HttpResponseMessage httpResponseMessage)
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(httpResponseMessage)
               .Verifiable();
            return handlerMock;
        }
    }
}