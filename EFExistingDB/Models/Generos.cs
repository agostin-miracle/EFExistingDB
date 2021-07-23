using System;
using System.Collections.Generic;

namespace EFExistingDB.Models
{
    public partial class Generos
    {
        public Generos()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public string CodGenero { get; set; }
        public string DesGenero { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
