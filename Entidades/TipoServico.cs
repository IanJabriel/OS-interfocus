using System.Text.Json.Serialization;

namespace Interfocus.Models
{
    public class TipoServico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        
        [JsonPropertyName("status_ct")]
        public int StatusCt{ get; set; }

        [JsonPropertyName("mudanca_contrato")]
        public int MudancaContrato{ get; set; }

        public TipoServico(string descricao)
        {
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
        }

        public TipoServico() { }
    }
}
