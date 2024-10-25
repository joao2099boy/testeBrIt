using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using _20241022_ApiTesteJoao.Extension.ConfigureExternalServices;
using _20241022_ApiTeste.Application.Extensions;
using _20241022_ApiTeste.Infraestructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicione a configura��o do DbContext e dos reposit�rios
builder.Services.AddInfrastructureServices("Host=localhost;Port=5432;Database=db_teste_processo;Username=develop_fitbank;Password=fit2024;");

// Adicione os servi�os da aplica��o
builder.Services.AddApplicationServices();

// Configure o AcessoApiServices
builder.Services.AddAcessoApiServices(builder.Configuration); // Chamada para registrar os servi�os do AcessoApi

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();