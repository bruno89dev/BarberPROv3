using AutoMapper;
using BarberPROv3.Data;
using BarberPROv3.DTO;
using BarberPROv3.Enums;
using BarberPROv3.Models;
using System.Collections.Generic;
using System.Linq;

namespace BarberPROv3.Services {
    public class ProdutoService {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProdutoService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public List<Produto> GetAll() {
            return _context.Produtos.ToList();
        }

        public List<Produto> GetActives() {
            return _context.Produtos.Where(x => x.RegistroAtivo == true).ToList();
        }

        public Produto GetById(int id) {
            return _context.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public Produto GetByName(string nome) {
            return _context.Produtos.Where(x => x.Nome.Contains(nome)).FirstOrDefault();
        }

        public List<Produto> GetByCategoria(Categoria categoria) {
            return _context.Produtos.Where(x => x.Categoria == categoria).ToList();
        }

        public Produto Create(ProdutoDTO ProdutoDTO) {
            var novoProduto = _mapper.Map<Produto>(ProdutoDTO);
            novoProduto.RegistroAtivo = true;
            _context.Produtos.Add(novoProduto);
            _context.SaveChanges();
            return novoProduto;
        }

        public Produto Update(ProdutoDTO produtoDTO) {
            var editProduto = _mapper.Map<Produto>(produtoDTO);
            _context.Produtos.Update(editProduto);
            _context.SaveChanges();
            return editProduto;
        }

        public Produto Deactivate(int id) {
            var deleteProduto = _context.Produtos.FirstOrDefault(x => x.Id == id);
            deleteProduto.RegistroAtivo = false;
            _context.SaveChanges();
            return deleteProduto;
        }

        public Produto Reactivate(int id) {
            var reactivateProduto = _context.Produtos.FirstOrDefault(x => x.Id == id);
            reactivateProduto.RegistroAtivo = true;
            _context.SaveChanges();
            return reactivateProduto;
        }
    }
}
