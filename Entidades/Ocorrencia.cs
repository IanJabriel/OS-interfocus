using System;
using System.Text.Json.Serialization;

namespace Interfocus.Models
{
    public class Ocorrencia
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Descricao { get; set; }
        public string Anexo { get; set; }

        public Ocorrencia(string descricao,string anexo)
        { 
            Descricao = descricao;
            Anexo = anexo;
        }

        public Ocorrencia() { }
    }
}