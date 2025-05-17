using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using DTOs;
using AutoMapper;

namespace Application.Services;

public class ContratoService : IContratoService
{
    private readonly IContratoRepository _contratoRepository;
    private readonly IMapper _mapper;

    public ContratoService(IContratoRepository contratoRepository, IMapper mapper)
    {
        _contratoRepository = contratoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ContratoDTO>> ListarAsync()
    {
        var contratos = await _contratoRepository.ObterTodosAsync();
        return _mapper.Map<IEnumerable<ContratoDTO>>(contratos);
    }

    public async Task<ContratoDTO?> ObterPorIdAsync(int id)
    {
        var contrato = await _contratoRepository.ObterPorIdAsync(id);
        return _mapper.Map<ContratoDTO?>(contrato);
    }

    public async Task CriarAsync(CreateContratoDto dto)
    {
        var contrato = _mapper.Map<Contrato>(dto);
        contrato.DataInicio = contrato.DataInicio.Date;
        contrato.DataVencimento = contrato.DataVencimento.Date;

        await _contratoRepository.AdicionarAsync(contrato);
    }

    public async Task AtualizarAsync(int id, ContratoDTO dto)
    {
        var contrato = _mapper.Map<Contrato>(dto);
        contrato.Id = id;
        await _contratoRepository.AtualizarAsync(contrato);
    }

    public async Task RemoverAsync(int id)
    {
        await _contratoRepository.RemoverAsync(id);
    }
}
