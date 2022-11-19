using System.ComponentModel.DataAnnotations;

namespace BarberPROv3.Models {
    public class Cliente {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(4, ErrorMessage = "O nome deve ter no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [MinLength(11, ErrorMessage = "O CPF deve ter {1} caracteres")]
        [MaxLength(15)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [MinLength(8, ErrorMessage = "O telefone deve ter no mínimo {1} caracteres")]
        [MaxLength(20)]
        public string Telefone { get; set; }
        public bool RegistroAtivo { get; set; }
    }
}
