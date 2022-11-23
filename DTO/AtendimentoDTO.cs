using BarberPROv3.Enums;
using BarberPROv3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarberPROv3.DTO {
    public class AtendimentoDTO {
        public int Id { get; set; }
        public Barbeiro Barbeiro { get; set; }
        public Cliente Cliente { get; set; }

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
