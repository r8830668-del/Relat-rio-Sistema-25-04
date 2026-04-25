using SistemaRelatorios.Models;
using System.Threading.Channels;

namespace SistemaRelatorios.Services
{
    public class FilaGeracaoRelatorios
    {
        private readonly Channel<RelatorioRequest> _fila = Channel.CreateUnbounded<RelatorioRequest>();
        public async ValueTask EscreverNaFila(RelatorioRequest pedido)
        {
            await _fila.Writer.WriteAsync(pedido);
        }
        public IAsyncEnumerable<RelatorioRequest>LerDaFila(CancellationToken ct)
        {
            return _fila.Reader.ReadAllAsync(ct);
        }
    }
}
