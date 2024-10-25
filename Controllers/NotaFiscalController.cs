using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _20241022_ApiTeste.Application.Interfaces.Services;
using _20241022_ApiTeste.Application.Models.NotaFiscal;
using _20241022_ApiTesteJoao.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace _20241022_ApiTesteJoao.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v1/notasfiscais")]

public class NotaFiscalController(
    INotaFiscalService notaFiscalService,
    ILogger<NotaFiscalController> logger) : BaseController(logger, "notas-fiscais")
{
    [HttpPost("")]
    public async Task<IResult> Create([FromBody] NotaFiscalModel notaFiscalModel)
    {
        _logger.LogInformation("Nota Fiscal Create Request: {@Model}", JsonConvert.SerializeObject(notaFiscalModel));

        var result = await notaFiscalService.AdicionarNotaFiscalAsync(notaFiscalModel);

        return Result(result);
    }

    [HttpPut("{id}")]
    public async Task<IResult> Update(int id, [FromBody] NotaFiscalModel notaFiscalModel)
    {
        _logger.LogInformation("Nota Fiscal Update Request: {@Model}", JsonConvert.SerializeObject(notaFiscalModel));

        if (id != notaFiscalModel.ClienteId)
        {
            return Results.BadRequest("ID da nota fiscal não corresponde.");
        }

        var result = await notaFiscalService.AtualizarNotaFiscalAsync(notaFiscalModel);

        return Result(result);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetById(int id)
    {
        _logger.LogInformation("Request: {NotaFiscalId}", id);

        var result = await notaFiscalService.ObterNotaFiscalPorIdAsync(id);

        return Result(result);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        _logger.LogInformation("Request: {NotaFiscalId}", id);

        var result = await notaFiscalService.ExcluirNotaFiscalAsync(id);

        return Result(result);
    }

    [HttpGet("")]
    public async Task<IResult> GetAll()
    {
        _logger.LogInformation("Request to get all nota fiscais.");

        var result = await notaFiscalService.ObterTodasNotasFiscaisAsync();

        return Result(result);
    }
}