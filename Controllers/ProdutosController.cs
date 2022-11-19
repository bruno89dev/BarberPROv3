using BarberPROv3.DTO;
using BarberPROv3.Enums;
using BarberPROv3.Models;
using BarberPROv3.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberPROv3.Controllers {

    [ApiController]
    [Route("api/v3/[controller]")]
    public class ProdutosController : ControllerBase {

        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService) {
            _produtoService = produtoService;
        }

        [HttpGet("ListarTodos")]
        public IActionResult Listar() {
            var listaProdutos = _produtoService.GetAll();
            if (listaProdutos.Count == 0)
                return NotFound("Nenhum produto cadastrado");
            return Ok(listaProdutos);
        }

        [HttpGet("Listar Ativos")]
        public IActionResult ListarAtivos() {
            var listaAtivos = _produtoService.GetActives();
            if (listaAtivos.Count == 0)
                return NotFound("Nenhum produto ativo cadastrado");
            return Ok(listaAtivos);
        }

        [HttpGet("Id")]
        public IActionResult BuscarPorId(int id) {
            var produtoPorId = _produtoService.GetById(id);
            if (produtoPorId == null)
                return NotFound($"Nenhum produto encontrado com o id {id}");
            return Ok(produtoPorId);
        }

        [HttpGet("Nome")]
        public IActionResult BuscarPorNome(string nome) {
            var produtoPorNome = _produtoService.GetByName(nome);
            if (produtoPorNome == null)
                return NotFound("Nenhum produto encontrado");
            return Ok(produtoPorNome);
        }

        [HttpGet("Categoria")]
        public IActionResult BuscarPorCategoria(Categoria categoria) {
            var produtoPorCpf = _produtoService.GetByCategoria(categoria);
            if (produtoPorCpf == null)
                return NotFound($"Nenhum produto encontrado na categoria {categoria}");
            return Ok(produtoPorCpf);
        }

        [HttpPost("Novo")]
        public IActionResult Cadastrar(ProdutoDTO produtoDTO) {
            _produtoService.Create(produtoDTO);
            if (ModelState.IsValid) {
                Response.StatusCode = 201;
                return Ok("Produto adicionado com sucesso!");
            } else {
                return BadRequest("Não foi possível adicionar, confira os campos digitados e tente novamente");
            }
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar(ProdutoDTO produtoDTO) {
            _produtoService.Update(produtoDTO);
            if (ModelState.IsValid) {
                Response.StatusCode = 200;
                return Ok("Cadastro de produto atualizado com sucesso!");
            } else {
                return BadRequest("Não foi possível atualizar, confira os campos digitados e tente novamente");
            }
        }

        [HttpDelete("Desativar")]
        public IActionResult Desativar(int id) {
            var deleteBarbeiro = _produtoService.Deactivate(id);
            if (deleteBarbeiro != null) {
                Response.StatusCode = 200;
                return Ok("Cadastro de produto desativado com sucesso!");
            } else {
                Response.StatusCode = 403;
                return BadRequest($"Não foi possível desativar, nenhum produto encontrado com o id {id}");
            }
        }

        [HttpPost("Reativar")]
        public IActionResult Reativar(int id) {
            var deleteBarbeiro = _produtoService.Reactivate(id);
            if (deleteBarbeiro != null) {
                Response.StatusCode = 200;
                return Ok("Cadastro de produto reativado com sucesso!");
            } else {
                Response.StatusCode = 403;
                return BadRequest($"Não foi possível reativar, nenhum produto encontrado com o id {id}");
            }
        }
    }
}
