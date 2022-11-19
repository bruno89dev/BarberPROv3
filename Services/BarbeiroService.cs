using AutoMapper;
using BarberPROv3.Data;
using BarberPROv3.DTO;
using BarberPROv3.Models;
using System.Collections.Generic;
using System.Linq;

namespace BarberPROv3.Services {
    public class BarbeiroService {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BarbeiroService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public List<Barbeiro> GetAll() {
            return _context.Barbeiros.ToList();
        }

        public List<Barbeiro> GetActives() {
            return _context.Barbeiros.Where(x => x.RegistroAtivo == true).ToList();
        }

        public Barbeiro GetById(int id) {
            return _context.Barbeiros.FirstOrDefault(x => x.Id == id);
        }

        public Barbeiro GetByName(string nome) {
            return _context.Barbeiros.Where(x => x.Nome.Contains(nome)).FirstOrDefault();
        }

        public Barbeiro GetByCpf(string cpf) {
            return _context.Barbeiros.SingleOrDefault(x => x.Cpf == cpf);
        }

        public Barbeiro GetByEmail(string email) {
            return _context.Barbeiros.SingleOrDefault(x => x.Email == email);
        }

        public Barbeiro GetByPhone(string telefone) {
            return _context.Barbeiros.FirstOrDefault(x => x.Telefone == telefone);
        }

        public Barbeiro Create(BarbeiroDTO barbeiroDTO) {
            var novoBarbeiro = _mapper.Map<Barbeiro>(barbeiroDTO);
            novoBarbeiro.RegistroAtivo = true;
            _context.Barbeiros.Add(novoBarbeiro);
            _context.SaveChanges();
            return novoBarbeiro;
        }

        public Barbeiro Update(BarbeiroDTO barbeiroDTO) {
            var editBarbeiro = _mapper.Map<Barbeiro>(barbeiroDTO);
            _context.Barbeiros.Update(editBarbeiro);
            _context.SaveChanges();
            return editBarbeiro;
        }

        public Barbeiro Deactivate(int id) {
            var deleteBarbeiro = _context.Barbeiros.FirstOrDefault(x =>x.Id == id);
            deleteBarbeiro.RegistroAtivo = false;
            _context.SaveChanges();
            return deleteBarbeiro;
        }

        public Barbeiro Reactivate(int id) {
            var reactivateBarbeiro = _context.Barbeiros.FirstOrDefault(x =>x.Id == id);
            reactivateBarbeiro.RegistroAtivo = true;
            _context.SaveChanges();
            return reactivateBarbeiro;
        }
    }
}
