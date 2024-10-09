using System;

namespace Interfocus.Models
{
    public class Ocorrencia
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool Anexo { get; set; }

        public Ocorrencia(string descricao,bool anexo)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Anexo = anexo;
        }
    }
}
