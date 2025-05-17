using AutoMapper;
using Domain.Entities;
using DTOs;

namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Operadora, OperadoraDTO>().ReverseMap();
        CreateMap<Operadora, CreateOperadoraDTO>().ReverseMap();
        CreateMap<Contrato, ContratoDTO>().ReverseMap();
        CreateMap<Contrato, CreateContratoDto>().ReverseMap();
        CreateMap<Fatura, FaturaDTO>().ReverseMap();
    }
}