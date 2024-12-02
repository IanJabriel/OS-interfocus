using System;
using System.Text.Json.Serialization;

namespace ApiCrud.src.Entidades
{
    public class Ocorrencia
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
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