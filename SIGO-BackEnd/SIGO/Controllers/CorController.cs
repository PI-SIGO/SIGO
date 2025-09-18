using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIGO.Objects.Contracts;
using SIGO.Services.Interfaces;

namespace SIGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorController : ControllerBase
    {
        private readonly ICorService _corService;
        private readonly Response _response;
        private readonly IMapper _mapper;

        public CorController(ICorService corService, IMapper mapper)
        {
            _corService = corService;
            _mapper = mapper;
            _response = new Response();
        }

        // GET api/cor
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cores = await _corService.GetAll();

            _response.Code = ResponseEnum.SUCCESS;
            _response.Data = cores;
            _response.Message = "Cores listadas com sucesso";

            return Ok(_response);
        }

        // GET api/cor/nome/{nome}
        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            var cores = await _corService.GetByNome(nome);

            if (!cores.Any())
                return NotFound(new { Message = "Nenhuma cor encontrada com esse nome" });

            return Ok(cores);
        }
    }
}
