using System.ComponentModel.DataAnnotations;

namespace BarberPROv3.DTO {
    public class AtendimentoItemDTO {

        [Required(ErrorMessage = "O produto deve ser informado.")]
        public int ProdutoId { get; set; }
      
        [Required(ErrorMessage = "A quantidade deve ser informada.")]
        public int Quantidade { get; set; }
    }
}
