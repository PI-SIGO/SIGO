using AutoMapper;
using SIGO.Data.Interfaces;
using SIGO.Objects.Dtos.Entities;
using SIGO.Objects.Models;
using SIGO.Services.Interfaces;

namespace SIGO.Services.Entities
{
    public class ServicoService : GenericService<Servico, ServicoDTO>, IServicoService
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IMapper _mapper;

        public ServicoService(IServicoRepository servicoRepository, IMapper mapper)
            : base(servicoRepository, mapper)
        {
            _servicoRepository = servicoRepository;
            _mapper = mapper;
        }
        public override async Task<IEnumerable<ServicoDTO>> GetAll()
        {
            var entities = await _servicoRepository.Get();
            return _mapper.Map<IEnumerable<ServicoDTO>>(entities);
        }

        public async Task<ServicoDTO?> GetByIdWithDetails(int id)
        {
            var entity = await _servicoRepository.GetByIdWithDetails(id);
            return _mapper.Map<ServicoDTO?>(entity);
        }

        public async Task<IEnumerable<ServicoDTO>> GetByNameWithDetails(string nome)
        {
            var entities = await _servicoRepository.GetByNameWithDetails(nome);
            return _mapper.Map<IEnumerable<ServicoDTO>>(entities);
        }

        public async Task<ServicoDTO?> GetById(int id)
        {
            var entity = await _servicoRepository.GetById(id);
            return _mapper.Map<ServicoDTO?>(entity);
        }

        public async Task<ServicoDTO> Create(ServicoDTO servicoDTO)
        {
            var servico = _mapper.Map<Servico>(servicoDTO);
            servico = await _servicoRepository.Add(servico);
            return _mapper.Map<ServicoDTO>(servico);
        }
    }
}
