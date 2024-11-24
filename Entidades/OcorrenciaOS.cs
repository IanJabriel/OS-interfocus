using System;
using System.Text.Json.Serialization;

namespace Interfocus.Models
{
    public class OcorrenciaOS
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [JsonPropertyName("id_os")]
        public Guid IdOrdemServico { get; set; }
        [JsonPropertyName("id_ocorrencia")]
        public Guid IdOcorrencia { get; set; }

        [JsonIgnore]
        public OrdemServico OrdemServico { get; set; }
        [JsonIgnore]
        public Ocorrencia Ocorrencia { get; set; }
    }
}
