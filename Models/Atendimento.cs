using BarberPROv3.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarberPROv3.Models {
    public class Atendimento {
        public int Id { get; set; }

        [Required]
        public Barbeiro Barbeiro { get; set; }

        [Required]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "A data deve ser informada")]
        [DisplayFormat(DataFormatString = "{0:DD.MM.YYYY}")]
        public DateTime Data { get; set; }
        public FormaPagamento FormaDePagamento { get; set; }
        public List<AtendimentoItem> ItensVendidos { get; set; }
        
        [Required(ErrorMessage = "O caixa deve ser informado")]
        public Caixa CaixaDestino { get; set; }
        public bool RegistroAtivo { get; set; }
    }
}
