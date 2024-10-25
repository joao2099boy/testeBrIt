using System;
using System.Threading.Tasks;
using _20241022_ApiTeste.Application.Interfaces.Services;
using _20241022_ApiTeste.Application.Models.Produto;
using _20241022_ApiTesteJoao.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace _20241022_ApiTesteJoao.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v1/produtos")] 
public class ProdutoController : BaseController
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(
        IProdutoService produtoService,
        ILogger<ProdutoController> logger) : base(logger, "produto")
    {
        _produtoService = produtoService;
    }

    [HttpPost("")]
    public async Task<IResult> Create([FromBody] ProdutoModel produtoModel)
    {
        _logger.LogInformation("Produto Create Request: {@Model}", JsonConvert.SerializeObject(produtoModel));

        var result = await _produtoService.AdicionarProdutoAsync(produtoModel);

        return Result(result);
    }

    [HttpPut("{id}")]
    public async Task<IResult> Update(int id, [FromBody] ProdutoModel produtoModel)
    {
        _logger.LogInformation("Produto Update Request: {@Model}", JsonConvert.SerializeObject(produtoModel));

        if (id != produtoModel.ProdutoId)
        {
            return Results.BadRequest("ID do produto não corresponde.");
        }

        var result = await _produtoService.AtualizarProdutoAsync(produtoModel);

        return Result(result);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetById(int id)
    {
        _logger.LogInformation("Request: {ProdutoId}", id);

        var result = await _produtoService.ObterProdutoPorIdAsync(id);

        return Result(result);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        _logger.LogInformation("Request: {ProdutoId}", id);

        var result = await _produtoService.ExcluirProdutoAsync(id);

        return Result(result);
    }

    [HttpGet("")]
    public async Task<IResult> GetAll()
    {
        _logger.LogInformation("Request to get all products.");

        var result = await _produtoService.ObterTodosProdutosAsync();

        return Result(result);
    }

    [HttpGet("total-vendas")]
    public async Task<IResult> GetTotalVendasPorProduto()
    {
        _logger.LogInformation("Request to get total sales by product.");

        var result = await _produtoService.ObterTotalVendasPorProdutoAsync();

        return Result(result);
    }
}