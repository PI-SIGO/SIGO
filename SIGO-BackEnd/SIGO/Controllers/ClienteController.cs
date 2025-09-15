using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGO.Objects.Contracts;
using SIGO.Services.Interfaces;

namespace SIGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly Response _response;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
            _response = new Response();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clienteDTO = await _clienteService.GetAll();

            _response.Code = ResponseEnum.SUCCESS;
            _response.Data = clienteDTO;
            _response.Message = "Clientes listados com sucesso";

            return Ok(_response);
        }
        [HttpGet("{id}/detalhes")]
        public async Task<IActionResult> GetByIdWithDetails(int id)
        {
            var clienteDto = await _clienteService.GetByIdWithDetails(id);

            if (clienteDto is null)
                return NotFound(new { Message = "Cliente não encontrado" });

            return Ok(clienteDto);
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetByNameWithDetails(string nome)
        {
            var clientesDto = await _clienteService.GetByNameWithDetails(nome);

            if (!clientesDto.Any())
                return NotFound(new { Message = "Nenhum cliente encontrado com esse nome" });

            return Ok(clientesDto);
        }

        [HttpGet("{id}/basico")]
        public async Task<IActionResult> GetById(int id)
        {
            var clienteDto = await _clienteService.GetById(id);

            if (clienteDto is null)
                return NotFound(new { Message = "Cliente não encontrado" });

            return Ok(clienteDto);
        }
    }
}
