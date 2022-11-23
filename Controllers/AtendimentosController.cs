using BarberPROv3.DTO;
using BarberPROv3.Enums;
using BarberPROv3.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberPROv3.Controllers {

    [ApiController]
    [Route("api/v3/[controller]")]
    public class AtendimentosController : ControllerBase {

        private readonly AtendimentoService _atendimentoService;

        public AtendimentosController(AtendimentoService atendimentoService) {
            _atendimentoService = atendimentoService;
        }

        [HttpGet("ListarTodos")]
        public IActionResult Listar() {
            var listaAtendimentos = _atendimentoService.GetAll();
            if (listaAtendimentos.Count == 0)
                return NotFound("Nenhum atendimento cadastrado");
            return Ok(listaAtendimentos);
        }

        [HttpGet("Listar Ativos")]
        public IActionResult ListarAtivos() {
            var listaAtivos = _atendimentoService.GetActives();
            if (listaAtivos.Count == 0)
                return NotFound("Nenhum atendimento ativo cadastrado");
            return Ok(listaAtivos);
        }

        [HttpGet("Id")]
        public IActionResult BuscarPorId(int id) {
            var atendimentoPorId = _atendimentoService.GetById(id);
            if (atendimentoPorId == null)
                return NotFound($"Nenhum atendimento encontrado com o id {id}");
            return Ok(atendimentoPorId);
        }

        [HttpGet("Barbeiro")]
        public IActionResult BuscarPorBarbeiro(string nomeBarbeiro) {
            var atendimentoPorBarbeiro = _atendimentoService.GetByBarber(nomeBarbeiro);
            if (atendimentoPorBarbeiro.Count == 0)
                return NotFound($"Nenhum atendimento encontrado com o barbeiro {nomeBarbeiro}");
            return Ok(atendimentoPorBarbeiro);
        }

        [HttpGet("Cliente")]
        public IActionResult BuscarPorCpf(string nomeCliente) {
            var atendimentoPorCliente = _atendimentoService.GetByClient(nomeCliente);
            if (atendimentoPorCliente == null)
                return NotFound($"Nenhum atendimento encontrado com o cliente {nomeCliente}");
            return Ok(atendimentoPorCliente);
        }

        [HttpGet("Data")]
        public IActionResult BuscarPorData(DateTime data) {
            var atendimentoPorData = _atendimentoService.GetByDate(data);
            if (atendimentoPorData.Count == 0)
                return NotFound("Nenhum atendimento encontrado na data selecionada");
            return Ok(atendimentoPorData);
        }

        [HttpGet("FormaDePagamento")]
        public IActionResult BuscarPorFormaDePagamento(FormaPagamento formaPagamento) {
            var atendimentoPorFormaPgto = _atendimentoService.GetByPaymentType(formaPagamento);
            if (atendimentoPorFormaPgto.Count == 0)
                return NotFound("Nenhum atendimento encontrado com a forma de pagamento selecionada");
            return Ok(atendimentoPorFormaPgto);
        }

        [HttpPost("Novo")]
        public IActionResult Cadastrar(CriarAtendimentoDTO criarAtendimentoDTO) {
            _atendimentoService.Create(criarAtendimentoDTO);
            if (ModelState.IsValid) {
                Response.StatusCode = 201;
                return Ok("Atendimento adicionado com sucesso!");
            } else {
                return BadRequest("Não foi possível adicionar, confira os campos digitados e tente novamente");
            }
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar(AtendimentoDTO atendimentoDTO) {
            _atendimentoService.Update(atendimentoDTO);
            if (ModelState.IsValid) {
                Response.StatusCode = 200;
                return Ok("Cadastro de atendimento atualizado com sucesso!");
            } else {
                return BadRequest("Não foi possível atualizar, confira os campos digitados e tente novamente");
            }
        }

        [HttpDelete("Desativar")]
        public IActionResult Desativar(int id) {
            var deleteBarbeiro = _atendimentoService.Deactivate(id);
            if (deleteBarbeiro != null) {
                Response.StatusCode = 200;
                return Ok("Cadastro de atendimento desativado com sucesso!");
            } else {
                Response.StatusCode = 403;
                return BadRequest($"Não foi possível desativar, nenhum atendimento encontrado com o id {id}");
            }
        }
    }
}
