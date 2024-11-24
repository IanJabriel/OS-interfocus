using System.Text.Json.Serialization;

namespace Interfocus.Models
{
    public class TipoServico
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }
        
        [JsonPropertyName("status_ct")]
        public Guid StatusCt{ get; set; }

        [JsonPropertyName("mudanca_contrato")]
        public int MudancaContrato{ get; set; }
        // N lembro o pq colocamos int pq essencialmente isso poderia ser bool olhando agora em retrospecto ou nem ter mas vamos manter int, usa a logica q for padrão se n tiver padrão 0 siginifica mudança(sim) e 1 significa sem mudança(não)
        
        
        
        public TipoServico(string descricao)
        {
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
        }

        public TipoServico() { }
    }
}
