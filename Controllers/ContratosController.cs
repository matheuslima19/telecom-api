using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using DTOs;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContratosController : ControllerBase
{
    private readonly IContratoService _contratoService;

    public ContratosController(IContratoService contratoService)
    {
        _contratoService = contratoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await _contratoService.ListarAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _contratoService.ObterPorIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateContratoDto dto)
    {
        await _contratoService.CriarAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = 0 }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ContratoDTO dto)
    {
        await _contratoService.AtualizarAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _contratoService.RemoverAsync(id);
        return NoContent();
    }
}
