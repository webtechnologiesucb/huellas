using System;
using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly IHealthService _healthService;

        public HealthController(IHealthService healthService)
        {
            _healthService = healthService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHealth()
        {
            var response = await _healthService.CheckHealthAsync();

            if (!response.DatabaseConnected)
                return StatusCode(503, response);

            return Ok(response);
        }
    }
}
