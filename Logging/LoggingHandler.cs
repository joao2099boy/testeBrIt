using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class LoggingDelegatingHandler(ILogger<LoggingDelegatingHandler> logger) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Sending request to {Url}", request.RequestUri);

        var response = await base.SendAsync(request, cancellationToken);

        logger.LogInformation("Received response with status code {StatusCode}", response.StatusCode);

        return response;
    }
}