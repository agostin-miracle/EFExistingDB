using System;
using System.Collections.Generic;

namespace EFExistingDB.Models
{
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public byte CodEstCivil { get; set; }
        public string DesEstCivil { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
