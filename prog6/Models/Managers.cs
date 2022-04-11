using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace prog6.Models
{
    public partial class Managers
    {
        public int ManagerId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
