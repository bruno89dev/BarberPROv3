using AutoMapper;
using BarberPROv3.DTO;
using BarberPROv3.Models;

namespace BarberPROv3.Mapping {
    public class ClassToDTOMapping : Profile {
        public ClassToDTOMapping() {
            CreateMap<Atendimento, AtendimentoDTO>().ReverseMap();
            CreateMap<AtendimentoItem, AtendimentoItemDTO>().ReverseMap();
            CreateMap<Atendimento, CriarAtendimentoDTO>().ReverseMap();
            CreateMap<Barbeiro, BarbeiroDTO>().ReverseMap();
            CreateMap<Caixa, CaixaDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<MovCaixa, MovCaixaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
