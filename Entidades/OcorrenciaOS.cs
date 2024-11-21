using System;
using System.Text.Json.Serialization;

namespace Interfocus.Models
{
    public class OcorrenciaOS
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdOrdemServico { get; set; }
        public Guid IdOcorrencia { get; set; }

        [JsonIgnore]
        public OrdemServico OrdemServico { get; set; }
        [JsonIgnore]
        public Ocorrencia Ocorrencia { get; set; }
    }
}
