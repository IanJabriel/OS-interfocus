using System;
using System.Collections.Generic;

namespace Interfocus.Models
{
    public class OrdemServico
    {
        public Guid Id { get; set; }
        public Guid IdTipoServico { get; set; }
        public DateTime DataAgendamento { get; set; }
        public Guid IdContrato { get; set; }
        public Guid IdCliente { get; set; }
        public Guid IdStatusOS { get; set; }
        public Guid FuncionarioAbriu { get; set; }
        public Guid IdFuncionarioFechou { get; set; }

        public List<OcorrenciaOS> OcorrenciasOS { get; set; } = new List<OcorrenciaOS>();
        public StatusOS StatusOS { get; set; }
    }
}
//@DateTimeFormat(pattern = "dd/MM/yyyy")
