using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGO.Objects.Contracts;
using SIGO.Objects.Dtos.Entities;
using SIGO.Services.Interfaces;

namespace SIGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;
        private readonly Response _response;
        private readonly IMapper _mapper;

        public VeiculoController(IVeiculoService veiculoService, IMapper mapper)
        {
            _veiculoService = veiculoService;
            _mapper = mapper;
            _response = new Response();
        }

        // GET api/veiculo
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var veiculos = await _veiculoService.GetAll();

            _response.Code = ResponseEnum.SUCCESS;
            _response.Data = veiculos;
            _response.Message = "Veículos listados com sucesso";

            return Ok(_response);
        }

        // GET api/veiculo/placa/{placa}
        [HttpGet("placa/{placa}")]
        public async Task<IActionResult> GetByPlaca(string placa)
        {
            var veiculo = await _veiculoService.GetByPlaca(placa);

            if (veiculo is null)
                return NotFound(new { Message = "Veículo não encontrado com essa placa" });

            return Ok(veiculo);
        }

        // GET api/veiculo/tipo/{tipo}
        [HttpGet("tipo/{tipo}")]
        public async Task<IActionResult> GetByTipo(string tipo)
        {
            var veiculos = await _veiculoService.GetByTipo(tipo);

            if (!veiculos.Any())
                return NotFound(new { Message = "Nenhum veículo encontrado desse tipo" });

            return Ok(veiculos);
        }

        // PUT api/veiculo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VeiculoDTO veiculoDto)
        {
            if (veiculoDto == null)
                return BadRequest(new { Message = "Dados inválidos" });

            await _veiculoService.Update(veiculoDto, id);

            _response.Code = ResponseEnum.SUCCESS;
            _response.Data = veiculoDto;
            _response.Message = "Veículo atualizado com sucesso";

            return Ok(_response);
        }

        // DELETE api/veiculo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _veiculoService.Remove(id);

            _response.Code = ResponseEnum.SUCCESS;
            _response.Message = "Veículo removido com sucesso";

            return Ok(_response);
        }
    }
}
