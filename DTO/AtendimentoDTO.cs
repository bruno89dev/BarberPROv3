using BarberPROv3.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarberPROv3.DTO {
    public class AtendimentoDTO {
        public int Id { get; set; }
        
        [Required]
        public BarbeiroDTO Barbeiro { get; set; }
        
        [Required]
        public ClienteDTO Cliente { get; set; }

        [Required(ErrorMessage = "A data deve ser informada")]
        [DisplayFormat(DataFormatString = "{0:DD.MM.YYYY}")]
        public DateTime Data { get; set; }
        public FormaPagamento FormaDePagamento { get; set; }
        public List<AtendimentoItemDTO> ItensVendidos { get; set; }

        [Required(ErrorMessage = "O caixa deve ser informado")]
        public CaixaDTO CaixaDestino { get; set; }
        public bool RegistroAtivo { get; set; }
    }
}
