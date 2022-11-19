using System.ComponentModel;

namespace BarberPROv3.Enums {
    public enum Role {
        [Description("SuperUser")]
        SuperUser = 0,
        [Description("Admin")]
        Admin = 1,
        [Description("User")]
        User = 2
    }
}
