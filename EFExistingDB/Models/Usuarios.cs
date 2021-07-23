using System;
using System.Collections.Generic;

namespace EFExistingDB.Models
{
    public partial class Usuarios
    {
        public int Codusu { get; set; }
        public byte Starec { get; set; }
        public DateTime DatCadastro { get; set; }
        public DateTime DatAtualizacao { get; set; }
        public string TipGen { get; set; }
        public string CodPju { get; set; }
        public string Numrg { get; set; }
        public string CodCmf { get; set; }
        public string NomUsuario { get; set; }
        public string NomMae { get; set; }
        public DateTime Datnascto { get; set; }
        public int CodAtr { get; set; }
        public bool PesPolExp { get; set; }
        public string Ufemi { get; set; }
        public string OrgEmi { get; set; }
        public byte CodEstCivil { get; set; }

        public EstadoCivil CodEstCivilNavigation { get; set; }
        public Generos TipGenNavigation { get; set; }
        public Uf UfemiNavigation { get; set; }
    }
}
