using SistemaRelatorios.Services;

namespace SistemaRelatorios.Workers;

public class RelatorioWorker : BackgroundService
{
    private readonly FilaGeracaoRelatorios _fila;

    public RelatorioWorker(FilaGeracaoRelatorios fila)
    {
        _fila = fila;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("[Worker] Aguardando novos pedidos de relatórios...");
        await foreach(var pedido in _fila.LerDaFila(stoppingToken))
        {
            Console.WriteLine($"Worker] Iniciando geração de relatório para:{pedido.Nome}");
            await Task.Delay(10000, stoppingToken);
            Console.WriteLine($"[Worker] Relatório de {pedido.Nome} concluído e enviado para {pedido.Email}");
        }
    }
}
