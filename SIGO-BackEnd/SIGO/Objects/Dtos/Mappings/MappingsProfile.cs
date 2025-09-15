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
                .ForMember(dest => dest.Enderecos,
                           opt => opt.MapFrom(src => src.EnderecoClientes))
                .ForMember(dest => dest.Telefones,
                           opt => opt.MapFrom(src => src.Telefones))
                .ReverseMap();

            CreateMap<EnderecoCliente, EnderecoClienteDTO>()
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
                .ReverseMap();

            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<Telefone, TelefoneDTO>().ReverseMap();
        }
    }
}
