using System.Text.Json.Serialization;

namespace Interfocus.Models
{
    public class TipoServico
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        
        [JsonPropertyName("status_ct")]
        public Guid StatusCt{ get; set; }

        [JsonPropertyName("mudanca_contrato")]
        public int MudancaContrato{ get; set; }

        public TipoServico(string descricao)
        {
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
        }

        public TipoServico() { }
    }
}
