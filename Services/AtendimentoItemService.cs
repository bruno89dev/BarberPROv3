using AutoMapper;
using BarberPROv3.Data;
using BarberPROv3.DTO;
using BarberPROv3.Models;

namespace BarberPROv3.Services {
    public class AtendimentoItemService {

        private AppDbContext _context;
        private ProdutoService _produtoService;

        public AtendimentoItemService(AppDbContext context, ProdutoService produtoService) {
            _context = context;
            _produtoService = produtoService;
        }

        public List<Produto> AddItem() {
            var atendimentoItem = new AtendimentoItem();
            var listaItens = _produtoService.GetAll();
            foreach (var item in listaItens) {
                atendimentoItem.Produto = item;
                _context.Add(atendimentoItem);
            }
            _context.SaveChanges();
            return listaItens;

        }
    }
}
