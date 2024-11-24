using System;
using System.Text.Json.Serialization;

namespace Interfocus.Models
{
    public class Ocorrencia
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }
        [JsonPropertyName("anexo")]
        public string Anexo { get; set; }

        public Ocorrencia(string descricao, string anexo)
        {
            Descricao = descricao;
            Anexo = anexo;
        }

        public Ocorrencia() { }
    }
}