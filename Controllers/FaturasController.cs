using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using DTOs;

namespace TelecomApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FaturasController : ControllerBase
{
    private readonly IFaturaService _faturaService;

    public FaturasController(IFaturaService faturaService)
    {
        _faturaService = faturaService;
    }

    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await _faturaService.ListarAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _faturaService.ObterPorIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FaturaDTO dto)
    {
        await _faturaService.CriarAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = 0 }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] FaturaDTO dto)
    {
        await _faturaService.AtualizarAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _faturaService.RemoverAsync(id);
        return NoContent();
    }
}
