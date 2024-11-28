using System;
using System.Text.Json.Serialization;

namespace Interfocus.Models
{
    public class OcorrenciaOS
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("id_os")]
        public int IdOrdemServico { get; set; }
        [JsonPropertyName("id_ocorrencia")]
        public int IdOcorrencia { get; set; }
    }
}