using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGO.Objects.Contracts;
using SIGO.Objects.Dtos.Entities;
using SIGO.Services.Entities;
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

        [HttpGet("GetCliente")]
        public async Task<IActionResult> GetAll()
        {
            var clienteDTO = await _clienteService.GetAll();

            _response.Code = ResponseEnum.SUCCESS;
            _response.Data = clienteDTO;
            _response.Message = "Clientes listados com sucesso";

            return Ok(_response);
        }

        [HttpGet("GetClienteById{id}")]
        public async Task<IActionResult> GetByIdWithDetails(int id)
        {
            var clienteDto = await _clienteService.GetByIdWithDetails(id);

            if (clienteDto is null)
                return NotFound(new { Message = "Cliente não encontrado" });

            return Ok(clienteDto);
        }

        [HttpGet("GetClienteByhNome/{nome}")]
        public async Task<IActionResult> GetByNameWithDetails(string nome)
        {
            var clientesDto = await _clienteService.GetByNameWithDetails(nome);

            if (!clientesDto.Any())
                return NotFound(new { Message = "Nenhum cliente encontrado com esse nome" });

            return Ok(clientesDto);
        }

        [HttpPost("PostCliente")]
        public async Task<IActionResult> Post(ClienteDTO clienteDTO)
        {
            if (clienteDTO is null)
            {
                _response.Code = ResponseEnum.INVALID;
                _response.Data = null;
                _response.Message = "Dados inválidos";

                return BadRequest(_response);
            }

            try
            {
                clienteDTO.Id = 0;

                clienteDTO.Telefones = null;

                await _clienteService.Create(clienteDTO);

                _response.Code = ResponseEnum.SUCCESS;
                _response.Data = clienteDTO;
                _response.Message = "Cliente cadastrado com sucesso";

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Code = ResponseEnum.ERROR;
                _response.Message = "Não foi possível cadastrar o cliente";
                _response.Data = new
                {
                    ErrorMessage = ex.Message,
                    StackTrace = ex.StackTrace ?? "No stack trace available"
                };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut("PutCliente{id}")]
        public async Task<IActionResult> Put(int id, ClienteDTO clienteDTO)
        {
            if (clienteDTO is null)
            {
                _response.Code = ResponseEnum.INVALID;
                _response.Data = null;
                _response.Message = "Dados inválidos";

                return BadRequest(_response);
            }

            try
            {
                clienteDTO.Telefones = null;

                var existingClienteDTO = await _clienteService.GetById(id);
                if (existingClienteDTO is null)
                {
                    _response.Code = ResponseEnum.NOT_FOUND;
                    _response.Data = null;
                    _response.Message = "O cliente informado não existe";
                    return NotFound(_response);
                }

                await _clienteService.Update(clienteDTO, id);

                _response.Code = ResponseEnum.SUCCESS;
                _response.Data = clienteDTO;
                _response.Message = "Cliente atualizado com sucesso";

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Code = ResponseEnum.ERROR;
                _response.Message = "Ocorreu um erro ao tentar atualizar os dados do cliente";
                _response.Data = new
                {
                    ErrorMessage = ex.Message,
                    StackTrace = ex.StackTrace ?? "No stack trace available"
                };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("DeleteCliente{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var clienteDTO = await _clienteService.GetById(id);

                if (clienteDTO is null)
                {
                    _response.Code = ResponseEnum.NOT_FOUND;
                    _response.Data = null;
                    _response.Message = "Cliente não encontrado";
                    return NotFound(_response);
                }

                await _clienteService.Remove(id);

                _response.Code = ResponseEnum.SUCCESS;
                _response.Data = null;
                _response.Message = "Cliente deletado com sucesso";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Code = ResponseEnum.ERROR;
                _response.Message = "Ocorreu um erro ao deletar o cliente";
                _response.Data = new
                {
                    ErrorMessage = ex.Message,
                    StackTrace = ex.StackTrace ?? "No stack trace disponível"
                };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
