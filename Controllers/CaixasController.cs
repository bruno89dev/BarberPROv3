using BarberPROv3.DTO;
using BarberPROv3.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberPROv3.Controllers {
    
    [ApiController]
    [Route("api/v3/[controller]")]
    public class CaixasController : ControllerBase {

        private readonly CaixaService _caixaService;

        public CaixasController(CaixaService caixaService) {
            _caixaService = caixaService;
        }

        [HttpGet("ListarTodos")]
        public IActionResult Listar() {
            var listaCaixas = _caixaService.GetAll();
            if (listaCaixas.Count == 0)
                return NotFound("Nenhum caixa cadastrado");
            return Ok(listaCaixas);
        }

        [HttpGet("Id")]
        public IActionResult BuscarPorId(int id) {
            var caixaPorId = _caixaService.GetById(id);
            if (caixaPorId == null)
                return NotFound($"Nenhum caixa encontrado com o id {id}");
            return Ok(caixaPorId);
        }

        [HttpGet("Nome")]
        public IActionResult BuscarPorNome(string nome) {
            var caixaPorNome = _caixaService.GetByName(nome);
            if (caixaPorNome.Count == 0)
                return NotFound("Nenhum caixa encontrado");
            return Ok(caixaPorNome);
        }

        [HttpPost("Novo")]
        public IActionResult Cadastrar(CaixaDTO caixaDTO) {
            _caixaService.Create(caixaDTO);
            if (ModelState.IsValid) {
                Response.StatusCode = 201;
                return Ok("Caixa adicionado com sucesso!");
            } else {
                return BadRequest("Não foi possível adicionar, confira os campos digitados e tente novamente");
            }
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar(CaixaDTO caixaDTO) {
            _caixaService.Update(caixaDTO);
            if (ModelState.IsValid) {
                Response.StatusCode = 200;
                return Ok("Cadastro de caixa atualizado com sucesso!");
            } else {
                return BadRequest("Não foi possível atualizar, confira os campos digitados e tente novamente");
            }
        }
    }
}
