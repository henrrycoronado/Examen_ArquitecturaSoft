using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AppBackend.Models;
using AppBackend.Services;

namespace AppBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtractoController : ControllerBase
    {
        private readonly IExtractoService _extractoService;

        public ExtractoController(IExtractoService extractoService)
        {
            _extractoService = extractoService;
        }

        [HttpGet("historial")]
        public async Task<IActionResult> ConsultarHistorial([FromQuery] FiltroHistorial filtro)
        {
            var resultado = await _extractoService.ConsultarHistorial(filtro);
            return Ok(resultado);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarHistorial([FromQuery] string criterio)
        {
            var resultado = await _extractoService.BuscarHistorial(criterio);
            return Ok(resultado);
        }

        [HttpGet("exportar")]
        public async Task<IActionResult> ExportarHistorial([FromQuery] FiltroHistorial filtro)
        {
            var archivo = await _extractoService.ExportarHistorial(filtro);
            return File(archivo.Contenido, archivo.TipoContenido, archivo.NombreArchivo);
        }

        [HttpPost("transaccion")]
        public async Task<IActionResult> ReportarTransaccion([FromBody] Transaccion transaccion)
        {
            var resultado = await _extractoService.ReportarTransaccion(transaccion);
            return Ok(resultado);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AppBackend.Models;
using AppBackend.Services;

namespace AppBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // Endpoint público (aparece en Swagger)
        [HttpGet]
        public IActionResult Get(string palabra)
        {
            var result = _weatherService.GetForecast();
            return Ok(result);
        }

        // Endpoint oculto (no aparece en Swagger)
        //[ApiExplorerSettings(IgnoreApi = true)]
        [Authorize]
        [HttpGet("oculto")]
        public IActionResult GetHidden()
        {
            return Ok("Este endpoint está oculto en Swagger");
        }
    }
}
