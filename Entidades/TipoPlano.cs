using System;

namespace Interfocus.Models
{
    public class TipoPlano
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Plano> Planos { get; set; }
    }
}
