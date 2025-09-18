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
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneService _telefoneService;
        private readonly Response _response;
        private readonly IMapper _mapper;

        public TelefoneController(ITelefoneService telefoneService, IMapper mapper)
        {
            _telefoneService = telefoneService;
            _mapper = mapper;
            _response = new Response();
        }

        [HttpGet("GetTelefoneById{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var clienteDto = await _telefoneService.GetById(id);

            if (clienteDto is null)
                return NotFound(new { Message = "Cliente não encontrado" });

            return Ok(clienteDto);
        }

        [HttpGet("GetTelefoneByNomeCliente/{nome}")]
        public async Task<IActionResult> GetByNameWithDetails(string nome)
        {
            var clientesDto = await _telefoneService.GetTelefoneByNome(nome);

            if (!clientesDto.Any())
                return NotFound(new { Message = "Nenhum cliente encontrado com esse nome" });

            return Ok(clientesDto);
        }

        [HttpPost("PostCliente")]
        public async Task<IActionResult> Post(TelefoneDTO telefoneDTO)
        {
            if (telefoneDTO is null)
            {
                _response.Code = ResponseEnum.INVALID;
                _response.Data = null;
                _response.Message = "Dados inválidos";

                return BadRequest(_response);
            }

            try
            {
                telefoneDTO.Id = 0;

                await _telefoneService.Create(telefoneDTO);

                _response.Code = ResponseEnum.SUCCESS;
                _response.Data = telefoneDTO;
                _response.Message = "Telefone cadastrado com sucesso";

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Code = ResponseEnum.ERROR;
                _response.Message = "Não foi possível cadastrar o telefone";
                _response.Data = new
                {
                    ErrorMessage = ex.Message,
                    StackTrace = ex.StackTrace ?? "No stack trace available"
                };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut("PutCliente{id}")]
        public async Task<IActionResult> Put(int id, TelefoneDTO telefoneDTO)
        {
            if (telefoneDTO is null)
            {
                _response.Code = ResponseEnum.INVALID;
                _response.Data = null;
                _response.Message = "Dados inválidos";

                return BadRequest(_response);
            }

            try
            {
                var existingClienteDTO = await _telefoneService.GetById(id);
                if (existingClienteDTO is null)
                {
                    _response.Code = ResponseEnum.NOT_FOUND;
                    _response.Data = null;
                    _response.Message = "O telefone informado não existe";
                    return NotFound(_response);
                }

                await _telefoneService.Update(telefoneDTO, id);

                _response.Code = ResponseEnum.SUCCESS;
                _response.Data = telefoneDTO;
                _response.Message = "Telefone atualizado com sucesso";

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Code = ResponseEnum.ERROR;
                _response.Message = "Ocorreu um erro ao tentar atualizar os dados do telefone";
                _response.Data = new
                {
                    ErrorMessage = ex.Message,
                    StackTrace = ex.StackTrace ?? "No stack trace available"
                };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("DeleteTelefone{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var clienteDTO = await _telefoneService.GetById(id);

                if (clienteDTO is null)
                {
                    _response.Code = ResponseEnum.NOT_FOUND;
                    _response.Data = null;
                    _response.Message = "Cliente não encontrado";
                    return NotFound(_response);
                }

                await _telefoneService.Remove(id);

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
