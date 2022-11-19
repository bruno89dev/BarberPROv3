using System.ComponentModel;

namespace BarberPROv3.Enums {
    public enum FormaPagamento {
        [Description("Dinheiro")]
        Dinheiro = 1,
        [Description("Cartão de Débito")]
        Debito = 2,
        [Description("Cartão de Crédito")]
        Credito = 3,
        [Description("PIX")]
        PIX = 4
    }
}
