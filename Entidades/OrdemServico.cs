﻿using System;
using System.Text.Json.Serialization;

namespace Interfocus.Models
{
    public class OrdemServico
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [JsonPropertyName("id_tipo_servico")]
        public Guid IdTipoServico { get; set; }
        [JsonPropertyName("data_agendamento")]
        public DateTime DataAgendamento { get; set; }
        [JsonPropertyName("id_contrato")]
        public Guid IdContrato { get; set; }
        [JsonPropertyName("id_cliente")]
        public Guid IdCliente { get; set; }
        [JsonPropertyName("status_os")]
        public int IdStatusOS { get; set; }

        public StatusOS StatusOS { get; set; }
        [JsonPropertyName("funcionario_abriu")]
        public Guid IdFuncionarioAbriu { get; set; }
        [JsonPropertyName("funcionario_fechou")]
        public Guid? IdFuncionarioFechou { get; set; }

        public OrdemServico(Guid idTipoServico, DateTime dataAgendamento, Guid idContrato, Guid idCliente, Guid idFuncionarioAbriu, Guid? idFuncionarioFechou)
        {
            IdTipoServico = idTipoServico;
            DataAgendamento = dataAgendamento;
            IdContrato = idContrato;
            IdCliente = idCliente;

            StatusOS = new StatusOS
            {
                Descricao = "Aberto"
            };
            IdStatusOS = StatusOS.Id;

            IdFuncionarioAbriu = idFuncionarioAbriu;
            IdFuncionarioFechou = idFuncionarioFechou;
        }

        public OrdemServico() { }
    }
}