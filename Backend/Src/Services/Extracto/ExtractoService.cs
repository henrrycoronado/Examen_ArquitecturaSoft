using AppBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppBackend;

namespace AppBackend.Services
{
    public class ExtractoService : IExtractoService
    {
        private readonly AppDbContext _context;

        public ExtractoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaccion>> ConsultarHistorial(FiltroHistorial filtro)
        {
            var query = _context.Transacciones.AsQueryable();

            if (filtro.UsuarioId != null)
                query = query.Where(t => t.UsuarioId == filtro.UsuarioId);

            if (filtro.FechaDesde != null)
                query = query.Where(t => t.Fecha >= filtro.FechaDesde);

            if (filtro.FechaHasta != null)
                query = query.Where(t => t.Fecha <= filtro.FechaHasta);

            if (!string.IsNullOrWhiteSpace(filtro.Tipo))
                query = query.Where(t => t.Tipo == filtro.Tipo);

            return await query.OrderByDescending(t => t.Fecha).ToListAsync();
        }

        public async Task<IEnumerable<Transaccion>> BuscarHistorial(string criterio)
        {
            return await _context.Transacciones
                .Where(t => t.Descripcion.Contains(criterio) || t.Referencia.Contains(criterio))
                .OrderByDescending(t => t.Fecha)
                .ToListAsync();
        }

        public async Task<ArchivoExportado> ExportarHistorial(FiltroHistorial filtro)
        {
            var transacciones = await ConsultarHistorial(filtro);

            // Supongamos que tienes un helper para generar CSV o Excel
            var archivoBytes = ExportHelper.GenerarArchivoCSV(transacciones); // O Excel
            var archivo = new ArchivoExportado
            {
                NombreArchivo = $"Historial_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                Contenido = archivoBytes,
                TipoContenido = "text/csv"
            };

            return archivo;
        }

        public async Task<bool> ReportarTransaccion(Transaccion transaccion)
        {
            var existente = await _context.Transacciones.FindAsync(transaccion.Id);
            if (existente == null)
                return false;

            existente.Reportada = true;
            existente.MotivoReporte = transaccion.MotivoReporte;
            existente.FechaReporte = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
