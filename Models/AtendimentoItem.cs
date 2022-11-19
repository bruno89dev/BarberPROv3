using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberPROv3.Models {
    public class AtendimentoItem {
        public int Id { get; set; }
        
        [Required]
        public Produto Produto { get; set; }
        public int AtendimentoId { get; set; }
        public int Quantidade { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorTotal { get; set; }
    }
}
