using AppBackend.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AppBackend.Services
{
    public interface IExtractoService
    {
        Task<IEnumerable<Transaccion>> ConsultarHistorial(FiltroHistorial filtro);
        Task<IEnumerable<Transaccion>> BuscarHistorial(string criterio);
        Task<ArchivoExportado> ExportarHistorial(FiltroHistorial filtro);
        Task<bool> ReportarTransaccion(Transaccion transaccion);
    }
}
