using AutoMapper;
using BarberPROv3.Data;
using BarberPROv3.DTO;
using BarberPROv3.Enums;
using BarberPROv3.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberPROv3.Services {
    public class MovCaixaService {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MovCaixaService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public List<MovCaixa> GetAll() {
            return _context.MovimentacoesCaixa.Include(x => x.Caixa).ToList();
        }

        public List<MovCaixa> GetByDate(DateTime date) {
            return _context.MovimentacoesCaixa.Include(x => x.Caixa).Where(x => x.Data == date).ToList();
        }

        public List<MovCaixa> GetByType(TipoMovCaixa type) {
            return _context.MovimentacoesCaixa.Include(x => x.Caixa).Where(x => x.TipoMovimentacao == type).ToList();
        }

        public MovCaixa Create(MovCaixaDTO movCaixaDTO, decimal valor, int id) {
            var novaMovimentacao = _mapper.Map<MovCaixa>(movCaixaDTO);
            novaMovimentacao.ValorMovimentacao = valor;
            novaMovimentacao.Caixa = _context.Caixas.Where(x => x.Id == id).FirstOrDefault();
            novaMovimentacao.Caixa.Saldo += novaMovimentacao.Movimentar(valor);
            _context.MovimentacoesCaixa.Add(novaMovimentacao);
            _context.SaveChanges();
            return novaMovimentacao;
        }

        public MovCaixa Update(MovCaixaDTO movCaixaDTO) {
            var updateMovimentacao = _mapper.Map<MovCaixa>(movCaixaDTO);
            _context.MovimentacoesCaixa.Update(updateMovimentacao);
            _context.SaveChanges();
            return updateMovimentacao;
        }
    }
}
