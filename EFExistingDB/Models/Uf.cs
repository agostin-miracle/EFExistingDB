using System;
using System.Collections.Generic;

namespace EFExistingDB.Models
{
    public partial class Uf
    {
        public Uf()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public string CodUf { get; set; }
        public string DesUf { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
