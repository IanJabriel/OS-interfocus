using System;

namespace Interfocus.Models
{
    public class StatusOS
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public OrdemServico OrdemServico { get; set; }
    }
}
