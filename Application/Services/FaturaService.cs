using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using DTOs;
using AutoMapper;

namespace Application.Services;

public class FaturaService : IFaturaService
{
    private readonly IFaturaRepository _faturaRepository;
    private readonly IMapper _mapper;

    public FaturaService(IFaturaRepository faturaRepository, IMapper mapper)
    {
        _faturaRepository = faturaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FaturaDTO>> ListarAsync()
    {
        var faturas = await _faturaRepository.ObterTodasAsync();
        return _mapper.Map<IEnumerable<FaturaDTO>>(faturas);
    }

    public async Task<FaturaDTO?> ObterPorIdAsync(int id)
    {
        var fatura = await _faturaRepository.ObterPorIdAsync(id);
        return _mapper.Map<FaturaDTO?>(fatura);
    }

    public async Task CriarAsync(FaturaDTO dto)
    {
        var fatura = _mapper.Map<Fatura>(dto);
        fatura.DataEmissao = dto.DataEmissao.Date;
        fatura.DataVencimento = dto.DataVencimento.Date;
        await _faturaRepository.AdicionarAsync(fatura);
    }

    public async Task AtualizarAsync(int id, FaturaDTO dto)
    {
        var fatura = _mapper.Map<Fatura>(dto);
        fatura.Id = id;
        await _faturaRepository.AtualizarAsync(fatura);
    }

    public async Task RemoverAsync(int id)
    {
        await _faturaRepository.RemoverAsync(id);
    }
}
