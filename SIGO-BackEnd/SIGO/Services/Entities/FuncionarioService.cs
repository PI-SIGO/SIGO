using AutoMapper;
using SIGO.Data.Interfaces;
using SIGO.Data.Repositories;
using SIGO.Objects.Dtos.Entities;
using SIGO.Objects.Models;
using SIGO.Services.Interfaces;

namespace SIGO.Services.Entities
{
    public class FuncionarioService : GenericService<Funcionario, FuncionarioDTO>, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;
        public FuncionarioService(IFuncionarioRepository funcionarioRepository, IMapper mapper) : base(funcionarioRepository, mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FuncionarioDTO>> GetFuncionarioByNome(string nome)
        {
            var entities = await _funcionarioRepository.GetFuncionarioByNome(nome);
            return _mapper.Map<IEnumerable<FuncionarioDTO>>(entities);
        }
    }
}
