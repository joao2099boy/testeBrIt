using System;
using System.Threading.Tasks;
using _20241022_ApiTeste.Application.Interfaces.Services; 
using _20241022_ApiTeste.Application.Models.AcessoApi; 
using _20241022_ApiTesteJoao.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace _20241022_ApiTesteJoao.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/v1/posts")]
public class PostController : BaseController
{
    private readonly IAcessApiProcessService _acessApiProcessService;

    public PostController(
        IAcessApiProcessService acessApiProcessService,
        ILogger<PostController> logger) : base(logger, "post")
    {
        _acessApiProcessService = acessApiProcessService;
    }

    [HttpGet("")] 
    public async Task<IResult> GetPosts()
    {
        _logger.LogInformation("Request to get all posts.");

        var result = await _acessApiProcessService.GetPostsAsync();

        return Result(result);
    }
}