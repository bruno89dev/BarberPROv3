using BarberPROv3.DTO;
using BarberPROv3.Enums;
using BarberPROv3.Models;
using BarberPROv3.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberPROv3.Controllers {

    [ApiController]
    [Route("api/v3/[controller]")]
    public class MovCaixaController : Controller {

        private MovCaixaService _movCaixaService;

        public MovCaixaController(MovCaixaService movCaixaService) {
            _movCaixaService = movCaixaService;
        }

        [HttpGet("ListarTodos")]
        public IActionResult Listar() {
            var listaMovimentacoes = _movCaixaService.GetAll();
            if (listaMovimentacoes.Count == 0)
                return NotFound("Nenhuma movimentação cadastrada");
            return Ok(listaMovimentacoes);
        }

        [HttpGet("Data")]
        public IActionResult BuscarPorData(DateTime data) {
            var movPorData = _movCaixaService.GetByDate(data);
            if (movPorData.Count == 0)
                return NotFound("Nenhuma movimentação encontrada nesta data");
            return Ok(movPorData);
        }

        [HttpGet("Tipo")]
        public IActionResult BuscarPorTipo(TipoMovCaixa tipo) {
            var movPorData = _movCaixaService.GetByType(tipo);
            if (movPorData.Count == 0)
                return NotFound("Nenhuma movimentação encontrada com este tipo");
            return Ok(movPorData);
        }

        [HttpPost("Novo")]
        public IActionResult Cadastrar(MovCaixaDTO movCaixaDTO, decimal valor, int id) {
            _movCaixaService.Create(movCaixaDTO, valor, id);
            if (ModelState.IsValid) {
                Response.StatusCode = 201;
                return Ok("Movimentação adicionada com sucesso!");
            } else {
                return BadRequest("Não foi possível adicionar, confira os campos digitados e tente novamente");
            }
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar(MovCaixaDTO movCaixaDTO) {
            _movCaixaService.Update(movCaixaDTO);
            if (ModelState.IsValid) {
                Response.StatusCode = 200;
                return Ok("Cadastro de movimentação atualizado com sucesso!");
            } else {
                return BadRequest("Não foi possível atualizar, confira os campos digitados e tente novamente");
            }
        }
    }
}
