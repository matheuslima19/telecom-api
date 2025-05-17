using AutoMapper;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using DTOs;

namespace Application.Services;

public class OperadoraService : IOperadoraService
{
    private readonly IOperadoraRepository _operadoraRepository;
    private readonly IMapper _mapper;

    public OperadoraService(IOperadoraRepository operadoraRepository, IMapper mapper)
    {
        _operadoraRepository = operadoraRepository;
        _mapper = mapper;
    }

     public async Task<IEnumerable<OperadoraDTO>> ListarAsync()
    {
        var operadoras = await _operadoraRepository.ObterTodasAsync();
        return _mapper.Map<IEnumerable<OperadoraDTO>>(operadoras);
    }

    public async Task<OperadoraDTO?> ObterPorIdAsync(int id)
    {
        var operadora = await _operadoraRepository.ObterPorIdAsync(id);
        return _mapper.Map<OperadoraDTO?>(operadora);
    }

    public async Task CriarAsync(CreateOperadoraDTO dto)
    {
        var operadora = _mapper.Map<Operadora>(dto);
        await _operadoraRepository.AdicionarAsync(operadora);
    }

    public async Task AtualizarAsync(int id, OperadoraDTO dto)
    {
        var operadora = _mapper.Map<Operadora>(dto);
        operadora.Id = id;
        await _operadoraRepository.AtualizarAsync(operadora);
    }

    public async Task RemoverAsync(int id)
    {
        await _operadoraRepository.RemoverAsync(id);
    }
}