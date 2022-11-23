using AutoMapper;
using BarberPROv3.Data;
using BarberPROv3.DTO;
using BarberPROv3.Models;

namespace BarberPROv3.Services {
    public class CaixaService {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CaixaService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public List<Caixa> GetAll() {
            return _context.Caixas.ToList();
        }

        public Caixa GetById(int id) {
            return _context.Caixas.FirstOrDefault(x => x.Id == id);
        }

        public List<Caixa> GetByName(string name) {
            return _context.Caixas.Where(x => x.Nome.Contains(name)).ToList();
        }

        public Caixa Create(CaixaDTO caixaDTO) {
            var novoCaixa = _mapper.Map<Caixa>(caixaDTO);
            _context.Caixas.Add(novoCaixa);
            _context.SaveChanges();
            return novoCaixa;
        }

        public Caixa Update(CaixaDTO caixaDTO) {
            var novoCaixa = _mapper.Map<Caixa>(caixaDTO);
            _context.Caixas.Update(novoCaixa);
            _context.SaveChanges();
            return novoCaixa;
        }
    }
}
