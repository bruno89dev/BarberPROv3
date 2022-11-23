using BarberPROv3.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberPROv3.DTO {
    public class MovCaixaDTO {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O caixa deve ser informado")]
        public CaixaDTO Caixa { get; set; }

        [Required(ErrorMessage = "A data deve ser informada")]
        [DisplayFormat(DataFormatString = "{0:DD.MM.YYYY}")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O valor deve ser informado")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorMovimentacao { get; set; }
        public TipoMovCaixa TipoMovimentacao { get; set; }

    }
}
