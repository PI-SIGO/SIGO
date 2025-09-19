using AutoMapper;
using SIGO.Objects.Dtos.Entities;
using SIGO.Objects.Models;

namespace SIGO.Objects.Dtos.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>()
                .ForMember(dest => dest.Telefones, opt => opt.MapFrom(src => src.Telefones))
                .ReverseMap();

            CreateMap<Telefone, TelefoneDTO>().ReverseMap();
            CreateMap<MarcaDTO, Marca>().ReverseMap();

            CreateMap<Veiculo, VeiculoDTO>()
                .ForMember(dest => dest.Cores, opt => opt.MapFrom(src => src.Cor))
                .ReverseMap();
            CreateMap<Cor, CorDTO>().ReverseMap();

            CreateMap<Servico, ServicoDTO>().ReverseMap();
            CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
        }
    }
}