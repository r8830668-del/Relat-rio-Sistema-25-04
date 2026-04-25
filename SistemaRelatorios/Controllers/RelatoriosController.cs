using Microsoft.AspNetCore.Mvc;
using SistemaRelatorios.Models;
using SistemaRelatorios.Services;

namespace SistemaRelatorios.Controllers;

[ApiController]
[Route("api/controller")]

public class RelatoriosController : ControllerBase
{
    private readonly FilaGeracaoRelatorios _fila;
    public RelatoriosController(FilaGeracaoRelatorios fila)
    {
        _fila = fila;
    }

    [HttpPost]
    public async Task<IActionResult>SolicitarRelatorio([FromBody] RelatorioRequest request)
    {
        Console.WriteLine($"[API] recebido pedido para: {request.Nome}. enviando para fila ...");

        await _fila.EscreverNaFila(request);

        return Accepted(new { mensagem = $"Seu relatorio entrou na fila de processamento." });
    }

}
       
