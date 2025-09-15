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
                    opt => opt.MapFrom(src => src.EnderecoClientes.Select(ec => ec.Endereco)))
            .ReverseMap();

            CreateMap<Endereco, EnderecoClienteDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<Telefone, TelefoneDTO>().ReverseMap();
            CreateMap<EnderecoCliente, EnderecoClienteDTO>().ReverseMap();


        }
    }
}