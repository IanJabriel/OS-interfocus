using System;

namespace Interfocus.Models
{
    public class Ocorrencia
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Anexo { get; set; }

        public Ocorrencia(string descricao,string anexo)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Anexo = anexo;
        }

        public Ocorrencia() { }
    }
}
