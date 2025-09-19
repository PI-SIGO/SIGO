using AutoMapper;
using SIGO.Data.Interfaces;
using SIGO.Objects.Dtos.Entities;
using SIGO.Objects.Models;
using SIGO.Services.Interfaces;

namespace SIGO.Services.Entities
{
    public class VeiculoService : GenericService<Veiculo, VeiculoDTO>, IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public VeiculoService(IVeiculoRepository veiculoRepository, IMapper mapper)
            : base(veiculoRepository, mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoDTO?>> GetByPlaca(string placa)
        {
            var entity = await _veiculoRepository.GetByPlaca(placa);
            return _mapper.Map<IEnumerable<VeiculoDTO?>>(entity);
        }

        public async Task<IEnumerable<VeiculoDTO>> GetByTipo(string tipo)
        {
            var entities = await _veiculoRepository.GetByTipo(tipo);
            return _mapper.Map<IEnumerable<VeiculoDTO>>(entities);
        }

        public async Task<VeiculoDTO?> GetById(int id)
        {
            var entity = await _veiculoRepository.GetById(id);
            return _mapper.Map<VeiculoDTO?>(entity);
        }
        public async Task UpdateVeiculo(VeiculoDTO veiculoDto, int id)
        {
            var existingEntity = await _veiculoRepository.GetById(id);

            if (existingEntity == null)
                throw new KeyNotFoundException($"Veículo com id {id} não encontrado.");

            var entity = _mapper.Map<Veiculo>(veiculoDto);
            entity.Id = id;

            await _veiculoRepository.Update(entity);
        }

    }
}
