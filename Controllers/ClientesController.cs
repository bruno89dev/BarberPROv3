using BarberPROv3.DTO;
using BarberPROv3.Models;
using BarberPROv3.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberPROv3.Controllers {

    [ApiController]
    [Route("api/v3/[controller]")]
    public class ClientesController : ControllerBase {

        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService) {
            _clienteService = clienteService;
        }

        [HttpGet("ListarTodos")]
        public IActionResult Listar() {
            var listaClientes = _clienteService.GetAll();
            if (listaClientes.Count == 0)
                return NotFound("Nenhum cliente cadastrado");
            return Ok(listaClientes);
        }

        [HttpGet("Listar Ativos")]
        public IActionResult ListarAtivos() {
            var listaAtivos = _clienteService.GetActives();
            if (listaAtivos.Count == 0)
                return NotFound("Nenhum cliente ativo cadastrado");
            return Ok(listaAtivos);
        }

        [HttpGet("Id")]
        public IActionResult BuscarPorId(int id) {
            var clientePorId = _clienteService.GetById(id);
            if (clientePorId == null)
                return NotFound($"Nenhum cliente encontrado com o id {id}");
            return Ok(clientePorId);
        }

        [HttpGet("Nome")]
        public IActionResult BuscarPorNome(string nome) {
            var clientePorNome = _clienteService.GetByName(nome);
            if (clientePorNome == null)
                return NotFound("Nenhum cliente encontrado");
            return Ok(clientePorNome);
        }

        [HttpGet("CPF")]
        public IActionResult BuscarPorCpf(string cpf) {
            var clientePorCpf = _clienteService.GetByCpf(cpf);
            if (clientePorCpf == null)
                return NotFound($"Nenhum cliente encontrado com o CPF {cpf}");
            return Ok(clientePorCpf);
        }

        [HttpGet("Email")]
        public IActionResult BuscarPorEmail(string email) {
            var clientePorEmail = _clienteService.GetByEmail(email);
            if (clientePorEmail == null)
                return NotFound($"Nenhum cliente encontrado com o email {email}");
            return Ok(clientePorEmail);
        }

        [HttpPost("Novo")]
        public IActionResult Cadastrar(ClienteDTO clienteDTO) {
            _clienteService.Create(clienteDTO);
            if (ModelState.IsValid) {
                Response.StatusCode = 201;
                return Ok("Cliente adicionado com sucesso!");
            } else {
                return BadRequest("Não foi possível adicionar, confira os campos digitados e tente novamente");
            }
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar(ClienteDTO clienteDTO) {
            _clienteService.Update(clienteDTO);
            if (ModelState.IsValid) {
                Response.StatusCode = 200;
                return Ok("Cadastro de cliente atualizado com sucesso!");
            } else {
                return BadRequest("Não foi possível atualizar, confira os campos digitados e tente novamente");
            }
        }

        [HttpDelete("Desativar")]
        public IActionResult Desativar(int id) {
            var deleteBarbeiro = _clienteService.Deactivate(id);
            if (deleteBarbeiro != null) {
                Response.StatusCode = 200;
                return Ok("Cadastro de cliente desativado com sucesso!");
            } else {
                Response.StatusCode = 403;
                return BadRequest($"Não foi possível desativar, nenhum cliente encontrado com o id {id}");
            }
        }

        [HttpPost("Reativar")]
        public IActionResult Reativar(int id) {
            var deleteBarbeiro = _clienteService.Reactivate(id);
            if (deleteBarbeiro != null) {
                Response.StatusCode = 200;
                return Ok("Cadastro de cliente reativado com sucesso!");
            } else {
                Response.StatusCode = 403;
                return BadRequest($"Não foi possível reativar, nenhum cliente encontrado com o id {id}");
            }
        }
    }
}
