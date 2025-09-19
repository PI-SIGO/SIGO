﻿using AutoMapper;
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
    public class ServicoController : ControllerBase
    {
        private readonly IServicoService _servicoService;
        private readonly Response _response;
        private readonly IMapper _mapper;

        public ServicoController(IServicoService servicoService, IMapper mapper)
        {
            _servicoService = servicoService;
            _mapper = mapper;
            _response = new Response();
        }

        [HttpGet("GetServico")]
        public async Task<IActionResult> GetAll()
        {
            var servicoDTO = await _servicoService.GetAll();

            _response.Code = ResponseEnum.SUCCESS;
            _response.Data = servicoDTO;
            _response.Message = "Serviços listados com sucesso";

            return Ok(_response);
        }

        [HttpGet("GetServicoById{id}")]
        public async Task<IActionResult> GetByIdWithDetails(int id)
        {
            var servicoDto = await _servicoService.GetByIdWithDetails(id);

            if (servicoDto is null)
                return NotFound(new { Message = "Serviço não encontrado" });

            return Ok(servicoDto);
        }

        [HttpGet("GetServicoByhNome/{nome}")]
        public async Task<IActionResult> GetByNameWithDetails(string nome)
        {
            var servicoDto = await _servicoService.GetByNameWithDetails(nome);

            if (!servicoDto.Any())
                return NotFound(new { Message = "Nenhum serviço encontrado com esse nome" });

            return Ok(servicoDto);
        }

        [HttpPost("PostService")]
        public async Task<IActionResult> Post(ServicoDTO serviceDTO)
        {
            if (serviceDTO is null)
            {
                _response.Code = ResponseEnum.INVALID;
                _response.Data = null;
                _response.Message = "Dados inválidos";

                return BadRequest(_response);
            }

            try
            {
                serviceDTO.Id = 0;

                await _servicoService.Create(serviceDTO);

                _response.Code = ResponseEnum.SUCCESS;
                _response.Data = serviceDTO;
                _response.Message = "Serviço cadastrado com sucesso";

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Code = ResponseEnum.ERROR;
                _response.Message = "Não foi possível cadastrar o serviço";
                _response.Data = new
                {
                    ErrorMessage = ex.Message,
                    StackTrace = ex.StackTrace ?? "No stack trace available"
                };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut("PutServico{id}")]
        public async Task<IActionResult> Put(int id, ServicoDTO servicoDTO)
        {
            if (servicoDTO is null)
            {
                _response.Code = ResponseEnum.INVALID;
                _response.Data = null;
                _response.Message = "Dados inválidos";

                return BadRequest(_response);
            }

            try
            {
                var existingServiceDTO = await _servicoService.GetById(id);
                if (existingServiceDTO is null)
                {
                    _response.Code = ResponseEnum.NOT_FOUND;
                    _response.Data = null;
                    _response.Message = "O serviço informado não existe";
                    return NotFound(_response);
                }

                await _servicoService.Update(servicoDTO, id);

                _response.Code = ResponseEnum.SUCCESS;
                _response.Data = servicoDTO;
                _response.Message = "Serviço atualizado com sucesso";

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Code = ResponseEnum.ERROR;
                _response.Message = "Ocorreu um erro ao tentar atualizar os dados do serviço";
                _response.Data = new
                {
                    ErrorMessage = ex.Message,
                    StackTrace = ex.StackTrace ?? "No stack trace available"
                };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("DeleteServico{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var servicoDTO = await _servicoService.GetById(id);

                if (servicoDTO is null)
                {
                    _response.Code = ResponseEnum.NOT_FOUND;
                    _response.Data = null;
                    _response.Message = "Serviço não encontrado";
                    return NotFound(_response);
                }

                await _servicoService.Remove(id);

                _response.Code = ResponseEnum.SUCCESS;
                _response.Data = null;
                _response.Message = "Serviço deletado com sucesso";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Code = ResponseEnum.ERROR;
                _response.Message = "Ocorreu um erro ao deletar o serviço";
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
