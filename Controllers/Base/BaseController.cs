using _20241022_ApiTeste.Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace _20241022_ApiTesteJoao.Controllers.Base;

[ApiController]
public class BaseController : ControllerBase
{
    internal readonly ILogger _logger;
    internal readonly string _scopeDisplayName;

    public BaseController(ILogger logger, string scopeDisplayName)
    {
        _logger = logger;
        _scopeDisplayName = scopeDisplayName;
    }

    [NonAction]
    public IResult Result(Result message)
    {
        if (message.IsFailure)
        {
            _logger.LogWarning("Operação falhou: {@scopeDisplayName} - Erro: {Error}", _scopeDisplayName, message.Error);
            return Results.BadRequest(message.Error);
        }

        return Results.Ok(message);
    }

    public IResult Result<TModel>(TModel model, Result message)
    {
        if (message.IsFailure)
        {
            _logger.LogWarning("Falha ao criar o {@scopeDisplayName}: {Error}", _scopeDisplayName, message.Error);
            return Results.BadRequest(message.Error);
        }

        _logger.LogInformation("Finalizado processo {@scopeDisplayName} - Result: {@message}", _scopeDisplayName, JsonConvert.SerializeObject(message));
        return Results.Ok(model);
    }
}