using System;
using System.Collections.Generic;

namespace Interfocus.Models
{
    public class OrdemServico
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid IdTipoServico { get; set; }
        public DateTime DataAgendamento { get; set; }
        public Guid IdContrato { get; set; }
        public Guid IdCliente { get; set; }
        public int IdStatusOS { get; set; }
        public Guid IdFuncionarioAbriu { get; set; }
        public Guid? IdFuncionarioFechou { get; set; }

        //public ICollection<OcorrenciaOS> OcorrenciasOS { get; set; } = new List<OcorrenciaOS>();
        public StatusOS StatusOS { get; set; }

        public OrdemServico(Guid idTipoServico, DateTime dataAgendamento, Guid idContrato, Guid idCliente, Guid idFuncionarioAbriu, Guid? idFuncionarioFechou)
        {
            IdTipoServico = idTipoServico;
            DataAgendamento = dataAgendamento;
            IdContrato = idContrato;
            IdCliente = idCliente;
            IdStatusOS = (int)StatusOS.StatusTipo.Aberto;
            IdFuncionarioAbriu = idFuncionarioAbriu;
            IdFuncionarioFechou = idFuncionarioFechou;
            //OcorrenciasOS = new List<OcorrenciaOS>();
        }

        public OrdemServico(){ }
    }
}
