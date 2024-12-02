using System;

namespace ApiCrud.src.Entidades
{
    public class TipoPlano
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Plano> Planos { get; set; }
    }
}
