using System;

namespace Interfocus.Models
{
    public class Plano
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid IdTipo { get; set; }
        public bool Combo { get; set; }
        public Guid Tier { get; set; }

        public TipoPlano TipoPlano { get; set; }
    }
}
