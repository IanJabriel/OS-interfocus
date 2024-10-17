using System;

namespace Interfocus.Models
{
    public class OcorrenciaOS
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdOrdemServico { get; set; }
        public OrdemServico OrdemServico { get; set; }
        public Guid IdOcorrencia { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
    }
}
