using AutoMapper;
using BarberPROv3.Data;
using BarberPROv3.DTO;
using BarberPROv3.Enums;
using BarberPROv3.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberPROv3.Services {
    public class AtendimentoService {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly AtendimentoItemService _atendimentoItemService;

        public AtendimentoService(AppDbContext context, IMapper mapper, AtendimentoItemService atendimentoItemService) {
            _context = context;
            _mapper = mapper;
            _atendimentoItemService = atendimentoItemService;
        }

        public List<Atendimento> GetAll() {
            return _context.Atendimentos.Include(x => x.Barbeiro).Include(x => x.Cliente).ToList();
        }

        public List<Atendimento> GetActives() {
            return _context.Atendimentos.Include(x => x.Barbeiro).Include(x => x.Cliente).Where(x => x.RegistroAtivo == true).ToList();
        }

        public Atendimento GetById(int id) {
            return _context.Atendimentos.Include(x => x.Barbeiro).Include(x => x.Cliente).Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Atendimento> GetByBarber(string nomeBarbeiro) {
            return _context.Atendimentos.Include(x => x.Barbeiro).Include(x => x.Cliente).Where(x => x.Barbeiro.Nome.Contains(nomeBarbeiro)).ToList();
        }

        public List<Atendimento> GetByClient(string nomeCliente) {
            return _context.Atendimentos.Include(x => x.Barbeiro).Include(x => x.Cliente).Where(x => x.Cliente.Nome.Contains(nomeCliente)).ToList();
        }

        public List<Atendimento> GetByDate(DateTime date) {
            return _context.Atendimentos.Include(x => x.Barbeiro).Include(x => x.Cliente).Where(x => x.Data == date).ToList();
        }

        public List<Atendimento> GetByPaymentType(FormaPagamento formaPagamento) {
            return _context.Atendimentos.Include(x => x.Barbeiro).Include(x => x.Cliente).Where(x => x.FormaDePagamento == formaPagamento).ToList();
        }

        public Atendimento Create(AtendimentoDTO atendimentoDTO, int barbeiroId, int clienteId) {
            var novoAtendimento = _mapper.Map<Atendimento>(atendimentoDTO);
            novoAtendimento.Barbeiro = _context.Barbeiros.Where(x => x.Id == barbeiroId).FirstOrDefault();
            novoAtendimento.Cliente = _context.Clientes.Where(x => x.Id == clienteId).FirstOrDefault();
            //novoAtendimento.ItensVendidos = _atendimentoItemService.AddItem(produtoId);
            //novoAtendimento.CaixaDestino = novoAtendimento.DirecionarPagamento();
            _context.Atendimentos.Add(novoAtendimento);
            _context.SaveChanges();
            return novoAtendimento;
        }

        public Atendimento Update(AtendimentoDTO atendimentoDTO) {
            var editAtendimento = _mapper.Map<Atendimento>(atendimentoDTO);
            _context.Atendimentos.Update(editAtendimento);
            _context.SaveChanges();
            return editAtendimento;
        }

        public Atendimento Deactivate(int id) {
            var deleteAtendimento = _context.Atendimentos.Where(x => x.Id == id).FirstOrDefault();
            deleteAtendimento.RegistroAtivo = false;
            _context.SaveChanges();
            return deleteAtendimento;
        }
    }
}
