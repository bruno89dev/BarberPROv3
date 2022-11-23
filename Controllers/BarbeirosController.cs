using BarberPROv3.Data;
using BarberPROv3.DTO;
using BarberPROv3.Models;
using BarberPROv3.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberPROv3.Controllers {

    [ApiController]
    [Route("api/v3/[controller]")]
    public class BarbeirosController : ControllerBase {

        private readonly BarbeiroService _barbeiroService;

        public BarbeirosController(BarbeiroService barbeiroService) {
            _barbeiroService = barbeiroService;

        }

        [HttpGet("ListarTodos")]
        public IActionResult Listar() {
            var listaBarbeiros = _barbeiroService.GetAll();
            if (listaBarbeiros.Count == 0)
                return NotFound("Nenhum barbeiro cadastrado");
            return Ok(listaBarbeiros);
        }

        [HttpGet("Listar Ativos")]
        public IActionResult ListarAtivos() {
            var listaAtivos = _barbeiroService.GetActives();
            if (listaAtivos.Count == 0)
                return NotFound("Nenhum barbeiro ativo cadastrado");
            return Ok(listaAtivos);
        }

        [HttpGet("Id")]
        public IActionResult BuscarPorId(int id) {
            var barbeiroPorId = _barbeiroService.GetById(id);
            if (barbeiroPorId == null)
                return NotFound($"Nenhum barbeiro encontrado com o id {id}");
            return Ok(barbeiroPorId);
        }

        [HttpGet("Nome")]
        public IActionResult BuscarPorNome(string nome) {
            var barbeiroPorNome = _barbeiroService.GetByName(nome);
            if (barbeiroPorNome.Count == 0)
                return NotFound("Nenhum barbeiro encontrado");
            return Ok(barbeiroPorNome);
        }

        [HttpGet("CPF")]
        public IActionResult BuscarPorCpf(string cpf) {
            var barbeiroPorCpf = _barbeiroService.GetByCpf(cpf);
            if (barbeiroPorCpf == null)
                return NotFound($"Nenhum barbeiro encontrado com o CPF {cpf}");
            return Ok(barbeiroPorCpf);
        }

        [HttpGet("Email")]
        public IActionResult BuscarPorEmail(string email) {
            var barbeiroPorEmail = _barbeiroService.GetByEmail(email);
            if (barbeiroPorEmail == null)
                return NotFound($"Nenhum barbeiro encontrado com o email {email}");
            return Ok(barbeiroPorEmail);
        }

        [HttpPost("Novo")]
        public IActionResult Cadastrar(BarbeiroDTO barbeiroDTO) {
            _barbeiroService.Create(barbeiroDTO);
            if (ModelState.IsValid) {
                Response.StatusCode = 201;
                return Ok("Barbeiro adicionado com sucesso!");
            } else {
                return BadRequest("Não foi possível adicionar, confira os campos digitados e tente novamente");
            }
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar(BarbeiroDTO barbeiroDTO) {
            _barbeiroService.Update(barbeiroDTO);
            if (ModelState.IsValid) {
                Response.StatusCode = 200;
                return Ok("Cadastro de barbeiro atualizado com sucesso!");
            } else {
                return BadRequest("Não foi possível atualizar, confira os campos digitados e tente novamente");
            }
        }

        [HttpDelete("Desativar")]
        public IActionResult Desativar(int id) {
            var deleteBarbeiro = _barbeiroService.Deactivate(id);
            if (deleteBarbeiro != null) {
                Response.StatusCode = 200;
                return Ok("Cadastro de barbeiro desativado com sucesso!");
            } else {
                Response.StatusCode = 403;
                return BadRequest($"Não foi possível desativar, nenhum barbeiro encontrado com o id {id}");
            }
        }

        [HttpPost("Reativar")]
        public IActionResult Reativar(int id) {
            var deleteBarbeiro = _barbeiroService.Reactivate(id);
            if (deleteBarbeiro != null) {
                Response.StatusCode = 200;
                return Ok("Cadastro de barbeiro reativado com sucesso!");
            } else {
                Response.StatusCode = 403;
                return BadRequest($"Não foi possível reativar, nenhum barbeiro encontrado com o id {id}");
            }
        }
    }
}
