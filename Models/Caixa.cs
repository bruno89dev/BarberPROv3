using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberPROv3.Models {
    public class Caixa {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(4, ErrorMessage = "O nome deve ter no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "O nome deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Saldo { get; set; }
    }
}
