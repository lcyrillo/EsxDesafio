using System;
using System.Collections.Generic;

namespace ESX.DesafioSimplificado.Models
{
    public class Patrimonio
    {
        public int PatrimonioId { get; set; }
        public string Nome { get; set; }
        public int MarcaId { get; set; }
        public string Descricao { get; set; }
        public string NumTombo { get; set; }

        public Patrimonio()
        {
            NumTombo = new Guid().ToString();
        }
    }
}
