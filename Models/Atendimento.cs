using BarberPROv3.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberPROv3.Models {
    public class Atendimento {
        public int Id { get; set; }
        public int BarbeiroId { get; set; }
        public Barbeiro Barbeiro { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [DisplayFormat(DataFormatString = "{0:DD.MM.YYYY}")]
        public DateTime Data { get; set; }
        public ICollection<AtendimentoItem> ItensVendidos { get; set; } = new List<AtendimentoItem>();
        public FormaPagamento FormaDePagamento { get; set; }
        public int CaixaId { get; set; }
        public Caixa CaixaDestino { get; set; }
        public bool RegistroAtivo { get; set; }
        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalGeral { get; set; }

        public void CalcularTotalGeral()
        {
            TotalGeral = 0;
            foreach(var item in ItensVendidos)
            {
                TotalGeral += item.ValorTotal;
            }
        }

    }
}
