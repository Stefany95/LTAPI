using LT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {
        /// <summary>
        /// Metodop par abtener todas las paradas
        /// </summary>
        /// <returns></returns>

        [HttpGet("GetParadas")]
        public async Task<IActionResult> GetParadas()
        {
            try
            {
                var response = await LT.Process.Process.GetParadas();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las ciudades: {ex.Message}");
            }
        }

        /// <summary>
        /// Metodo para obtener viajes por ciudad
        /// </summary>
        /// <param name="search">Filtro a buscar</param>
        /// <returns></returns>

        [HttpPost("GetBusByCity")]
        public async Task<IActionResult> GetBusByCity([FromBody] SearchFilterBus search)
        {
            try
            {
                var response = await LT.Process.Process.GetBusByCity(search);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener datos del viaje: {ex.Message}");
            }
        }

        /// <summary>
        /// Metodo obtener asiento por viaje
        /// </summary>
        /// <param name="search">Filtro a buscar</param>
        /// <returns></returns>
        [HttpPost("GetAsientos")]
        public async Task<IActionResult> GetAsientos([FromBody] SearchFilterAsientos search)
        {
            try
            {
                var response = await LT.Process.Process.GetAsientos(search);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener datos del viaje: {ex.Message}");

            }

        }
    }
    }
