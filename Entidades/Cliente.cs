using System;
using System.Collections.Generic;

namespace Interfocus.Models
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public int IdContrato { get; set; } 
        public string CpfCnpj { get; set; }
        public int? IdCidade { get; set; }
        public int? IdEstado { get; set; }

        public ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
    }
}
