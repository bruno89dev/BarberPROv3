using AutoMapper;
using BarberPROv3.Data;
using BarberPROv3.DTO;
using BarberPROv3.Models;

namespace BarberPROv3.Services {
    public class AtendimentoItemService {

        private AppDbContext _context;
        private readonly IMapper _mapper;

        public AtendimentoItemService(AppDbContext context, IMapper mapper) {
            _context = context;
            
            _mapper = mapper;
        }

        public List<AtendimentoItem> AdicionarItens(List<AtendimentoItemDTO> itens)
        {
            var listaItens = _mapper.Map<List<AtendimentoItem>>(itens);
            foreach(var item in listaItens)
            {
                item.ValorTotal = CalcularValorDoItem(item);
                _context.AtendimentoItens.Add(item);
            }
            _context.SaveChanges();
            return listaItens;
        }

        public decimal CalcularValorDoItem(AtendimentoItem item)
        {
            Produto produto = _context.Produtos.FirstOrDefault(produto => produto.Id == item.ProdutoId);
            var valorDoItem = produto.Valor * item.Quantidade;
            return valorDoItem;
        }
    }
}
