using BarberPROv3.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberPROv3.Models {
    public class Produto {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(10, ErrorMessage = "O nome deve ter no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        public bool RegistroAtivo { get; set; }
    }
}
