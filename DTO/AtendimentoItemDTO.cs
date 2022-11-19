using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberPROv3.DTO {
    public class AtendimentoItemDTO {
        public int Id { get; set; }

        [Required]
        public ProdutoDTO Produto { get; set; }
        public int AtendimentoId { get; set; }
        public int Quantidade { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorTotal { get; set; }
    }
}
