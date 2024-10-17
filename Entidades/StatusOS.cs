using ApiCrud.Migrations;
using System;

namespace Interfocus.Models
{
    public class StatusOS
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public StatusTipo Tipo { get; set; }

        public enum StatusTipo
        {
            Aberto = 1,
            Fechado = 2,
            EmProgresso = 3,
            Cancelado = 4
        }

        public StatusOS(StatusTipo tipo,string descricao)
        { 
            Tipo = tipo;
            Descricao = descricao ?? throw new ArgumentException(nameof(descricao));
        }

        public StatusOS() { }
    }
}
