using System;

namespace Interfocus.Models
{
    public class Plano
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int IdTipo { get; set; }
        public bool Combo { get; set; }
        public int Tier { get; set; }

        public TipoPlano TipoPlano { get; set; }
    }
}
