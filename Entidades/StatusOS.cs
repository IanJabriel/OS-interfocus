using ApiCrud.Migrations;
using System;

namespace Interfocus.Models
{
    public class StatusOS
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }
        public StatusTipo Tipo { get; set; }

        public enum StatusTipo
        {
            Aberto = 1,
            EmAndamento = 2,
            Fechado = 3
        }

        public StatusOS(int id,StatusTipo tipo,string descricao)
        {
            Id = id;
            Tipo = tipo;
            Descricao = descricao ?? throw new ArgumentException(nameof(descricao));
        }

        public StatusOS() { }
    }
}
