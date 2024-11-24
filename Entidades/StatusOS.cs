using System.Text.Json.Serialization;
namespace Interfocus.Models
{
    public class StatusOS
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public StatusOS(int id,string descricao)
        {
            Id = id;
            Descricao = descricao ?? throw new ArgumentException(nameof(descricao));
        }

        public StatusOS() { }
    }
}
