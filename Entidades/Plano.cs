using System;

namespace ApiCrud.src.Entidades
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
