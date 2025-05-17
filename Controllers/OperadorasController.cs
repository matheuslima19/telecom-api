using Application.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperadorasController : ControllerBase
{
    private readonly IOperadoraService _operadoraService;

    public OperadorasController(IOperadoraService operadoraService)
    {
        _operadoraService = operadoraService;
    }

     [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await _operadoraService.ListarAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _operadoraService.ObterPorIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateOperadoraDTO dto)
    {
        await _operadoraService.CriarAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = 0 }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] OperadoraDTO dto)
    {
        await _operadoraService.AtualizarAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _operadoraService.RemoverAsync(id);
        return NoContent();
    }


}