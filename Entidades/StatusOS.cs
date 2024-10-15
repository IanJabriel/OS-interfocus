using System;

namespace Interfocus.Models
{
    public class StatusOS
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public OrdemServico OrdemServico { get; set; }

        public StatusOS(string descricao)
        { 
            Id = Guid.NewGuid();
            Descricao = descricao ?? throw new ArgumentException(nameof(descricao));
        }

        public StatusOS() { }
    }
}
