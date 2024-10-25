using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _20241022_ApiTeste.Application.Interfaces.Services;
using _20241022_ApiTeste.Application.Models.Cliente;
using _20241022_ApiTesteJoao.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace _20241022_ApiTesteJoao.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v1/clientes")] 
public class ClienteController(
    IClienteService clienteService,
    ILogger<ClienteController> logger) : BaseController(logger, "cliente")
{
    [HttpPost("")]
    public async Task<IResult> Create([FromBody] ClienteModel clienteModel)
    {
        _logger.LogInformation("Cliente Create Request: {@Model}", JsonConvert.SerializeObject(clienteModel));

        var result = await clienteService.AdicionarClienteAsync(clienteModel);

        return Result(result);
    }

    [HttpPut("{id}")]
    public async Task<IResult> Update(int id, [FromBody] ClienteModel clienteModel)
    {
        _logger.LogInformation("Cliente Update Request: {@Model}", JsonConvert.SerializeObject(clienteModel));

        if (id != clienteModel.ClienteId)
        {
            return Results.BadRequest("ID do cliente não corresponde.");
        }

        var result = await clienteService.AtualizarClienteAsync(clienteModel);

        return Result(result);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetById(int id)
    {
        _logger.LogInformation("Request: {ClienteId}", id);

        var result = await clienteService.ObterClientePorIdAsync(id);

        return Result(result);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        _logger.LogInformation("Request: {ClienteId}", id);

        var result = await clienteService.RemoverClienteAsync(id);

        return Result(result);
    }

    [HttpGet("")]
    public async Task<IResult> GetAll()
    {
        _logger.LogInformation("Request to get all clients.");

        var result = await clienteService.ObterTodosClientesAsync();

        return Result(result);
    }
}