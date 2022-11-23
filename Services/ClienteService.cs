using AutoMapper;
using BarberPROv3.Data;
using BarberPROv3.DTO;
using BarberPROv3.Models;
using System.Collections.Generic;
using System.Linq;

namespace BarberPROv3.Services {
    public class ClienteService {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClienteService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public List<Cliente> GetAll() {
            return _context.Clientes.ToList();
        }

        public List<Cliente> GetActives() {
            return _context.Clientes.Where(x => x.RegistroAtivo == true).ToList();
        }

        public Cliente GetById(int id) {
            return _context.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<Cliente> GetByName(string nome) {
            return _context.Clientes.Where(x => x.Nome.Contains(nome)).ToList();
        }

        public Cliente GetByCpf(string cpf) {
            return _context.Clientes.SingleOrDefault(x => x.Cpf == cpf);
        }

        public Cliente GetByEmail(string email) {
            return _context.Clientes.SingleOrDefault(x => x.Email == email);
        }

        public Cliente GetByPhone(string telefone) {
            return _context.Clientes.FirstOrDefault(x => x.Telefone == telefone);
        }

        public Cliente Create(ClienteDTO clienteDTO) {
            var novoCliente = _mapper.Map<Cliente>(clienteDTO);
            novoCliente.RegistroAtivo = true;
            _context.Clientes.Add(novoCliente);
            _context.SaveChanges();
            return novoCliente;
        }

        public Cliente Update(ClienteDTO clienteDTO) {
            var editCliente = _mapper.Map<Cliente>(clienteDTO);
            _context.Clientes.Update(editCliente);
            _context.SaveChanges();
            return editCliente;
        }

        public Cliente Deactivate(int id) {
            var deleteCliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            deleteCliente.RegistroAtivo = false;
            _context.SaveChanges();
            return deleteCliente;
        }

        public Cliente Reactivate(int id) {
            var reactivateCliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            reactivateCliente.RegistroAtivo = true;
            _context.SaveChanges();
            return reactivateCliente;
        }
    }
}
