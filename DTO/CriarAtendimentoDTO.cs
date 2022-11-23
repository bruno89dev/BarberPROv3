using System.ComponentModel.DataAnnotations;
using BarberPROv3.Enums;

namespace BarberPROv3.DTO
{
    public class CriarAtendimentoDTO
    {
        [Required(ErrorMessage = "O barbeiro deve ser informado.")]
        public int BarbeiroId { get; set; }

        [Required(ErrorMessage = "O cliente deve ser informado.")]
        public int ClienteId { get; set; }

        [DisplayFormat(DataFormatString = "{0:DD.MM.YYYY}")]
        public DateTime Data { get; set; } = DateTime.Now;       
        public List<AtendimentoItemDTO> ItensVendidos { get; set; }

        [Required(ErrorMessage = "A forma de pagamento deve ser informada.")]
        public FormaPagamento FormaDePagamento { get; set; }

        [Required(ErrorMessage = "O caixa deve ser informado.")]
        public int CaixaId { get; set; }
        public bool RegistroAtivo { get; set; }
    }
}