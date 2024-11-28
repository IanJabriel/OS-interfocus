using System;
using System.Text.Json.Serialization;

namespace Interfocus.Models
{
    public class OrdemServico
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("id_tipo_servico")]
        public int IdTipoServico { get; set; }

        [JsonPropertyName("data_agendamento")]
        public DateTime DataAgendamento { get; set; }

        [JsonPropertyName("id_contrato")]
        public int IdContrato { get; set; }

        [JsonPropertyName("id_cliente")]
        public int IdCliente { get; set; }

        [JsonPropertyName("id_status_os")]
        public int IdStatusOS { get; set; }

        [JsonPropertyName("funcionario_abriu")]
        public int IdFuncionarioAbriu { get; set; }

        [JsonPropertyName("funcionario_fechou")]
        public int? IdFuncionarioFechou { get; set; }

        public OrdemServico(int idTipoServico, DateTime dataAgendamento, int idContrato, int idCliente, int idFuncionarioAbriu, int? idFuncionarioFechou, int idStatusOS)
        {
            IdTipoServico = idTipoServico;
            DataAgendamento = dataAgendamento;
            IdContrato = idContrato;
            IdCliente = idCliente;
            IdFuncionarioAbriu = idFuncionarioAbriu;
            IdFuncionarioFechou = idFuncionarioFechou;
            IdStatusOS = idStatusOS;
        }

        public OrdemServico() { }
    }
}
