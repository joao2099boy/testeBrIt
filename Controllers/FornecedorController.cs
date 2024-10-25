using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _20241022_ApiTeste.Application.Interfaces.Services;
using _20241022_ApiTeste.Application.Models.Fornecedor;
using _20241022_ApiTesteJoao.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace _20241022_ApiTesteJoao.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v1/fornecedores")]

public class FornecedorController(
    IFornecedorService fornecedorService,
    ILogger<FornecedorController> logger) : BaseController(logger, "fornecedores")
{
    [HttpPost("")]
    public async Task<IResult> Create([FromBody] FornecedorModel fornecedorModel)
    {
        _logger.LogInformation("Fornecedor Create Request: {@Model}", JsonConvert.SerializeObject(fornecedorModel));

        var result = await fornecedorService.AdicionarFornecedorAsync(fornecedorModel);

        return Result(result);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetById(int id)
    {
        _logger.LogInformation("Request: {FornecedorId}", id);

        var result = await fornecedorService.ObterFornecedorPorIdAsync(id);

        return Result(result);
    }

    [HttpPut("{id}")]
    public async Task<IResult> Update(int id, [FromBody] FornecedorModel fornecedorModel)
    {
        _logger.LogInformation("Fornecedor Update Request: {@Model}", JsonConvert.SerializeObject(fornecedorModel));

        if (id != fornecedorModel.FornecedorId)
        {
            return Results.BadRequest("ID do fornecedor não corresponde.");
        }

        var result = await fornecedorService.AtualizarFornecedorAsync(fornecedorModel);

        return Result(result);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        _logger.LogInformation("Request: {FornecedorId}", id);

        var result = await fornecedorService.RemoverFornecedorAsync(id);

        return Result(result);
    }

    [HttpGet("")]
    public async Task<IResult> GetAll()
    {
        _logger.LogInformation("Request to get all fornecedores.");

        var result = await fornecedorService.ObterTodosFornecedoresAsync();

        return Result(result);
    }
}