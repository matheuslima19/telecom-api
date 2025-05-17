using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("resumo")]
    public async Task<IActionResult> GetResumo()
    {
        var resultado = await _dashboardService.ObterResumoAsync();
        return Ok(resultado);
    }
}
