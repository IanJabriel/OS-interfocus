using System.Text.Json.Serialization;

namespace Interfocus.Models
{
    public class TipoServico
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid IdContrato { get; set; }
        
        public TipoServico(string descricao)
        {
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
        }

        public TipoServico() { }
    }
}
