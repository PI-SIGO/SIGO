using AutoMapper;
using SIGO.Data.Interfaces;
using SIGO.Objects.Dtos.Entities;
using SIGO.Objects.Models;
using SIGO.Services.Interfaces;
using System.Runtime.ConstrainedExecution;

namespace SIGO.Services.Entities
{
    public class CorService : GenericService<Cor, CorDTO>, ICorService
    {
        private readonly ICorRepository _corRepository;
        private readonly IMapper _mapper;

        public CorService(ICorRepository corRepository, IMapper mapper)
            : base(corRepository, mapper)
        {
            _corRepository = corRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CorDTO>> GetByName(string nome)
        {
            var entities = await _corRepository.GetByNome(nome);
            return _mapper.Map<IEnumerable<CorDTO>>(entities);
        }

        public async Task<CorDTO?> GetById(int id)
        {
            var entity = await _corRepository.GetById(id);
            return _mapper.Map<CorDTO?>(entity);
        }

        public async Task UpdateCor(CorDTO corDto, int id)
        {
            var existingEntity = await _corRepository.GetById(id);

            if (existingEntity == null)
                throw new KeyNotFoundException($"Cor com id {id} não encontrada.");

            var entity = _mapper.Map<Cor>(corDto);
            entity.Id = id;

            await _corRepository.Update(entity);
        }

    }
}
