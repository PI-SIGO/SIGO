using AutoMapper;
using SIGO.Data.Interfaces;
using SIGO.Objects.Dtos.Entities;
using SIGO.Objects.Models;
using SIGO.Services.Interfaces;

namespace SIGO.Services.Entities
{
    public class ClienteService : GenericService<Cliente, ClienteDTO>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
            : base(clienteRepository, mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public override async Task<IEnumerable<ClienteDTO>> GetAll()
        {
            var entities = await _clienteRepository.Get();
            return _mapper.Map<IEnumerable<ClienteDTO>>(entities);
        }

        public async Task<ClienteDTO?> GetByIdWithDetails(int id)
        {
            var entity = await _clienteRepository.GetByIdWithDetails(id);
            return _mapper.Map<ClienteDTO?>(entity);
        }

        public async Task<IEnumerable<ClienteDTO>> GetByNameWithDetails(string nome)
        {
            var entities = await _clienteRepository.GetByNameWithDetails(nome);
            return _mapper.Map<IEnumerable<ClienteDTO>>(entities);
        }

        public async Task<ClienteDTO?> GetById(int id)
        {
            var entity = await _clienteRepository.GetById(id);
            return _mapper.Map<ClienteDTO?>(entity);
        }
    }
}
