using System.Text.Json.Serialization;

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
        public StatusOS StatusOS { get; set; }

        public Guid IdFuncionarioAbriu { get; set; }
        public Guid? IdFuncionarioFechou { get; set; }

        public OrdemServico(Guid idTipoServico, DateTime dataAgendamento, Guid idContrato, Guid idCliente, Guid idFuncionarioAbriu, Guid? idFuncionarioFechou)
        {
            IdTipoServico = idTipoServico;
            DataAgendamento = dataAgendamento;
            IdContrato = idContrato;
            IdCliente = idCliente;

            IdStatusOS = (int)StatusOS.StatusTipo.Aberto;

            StatusOS = new StatusOS
            {
                Tipo = StatusOS.StatusTipo.Aberto, 
                Descricao = "Aberto"
            };

            IdFuncionarioAbriu = idFuncionarioAbriu;
            IdFuncionarioFechou = idFuncionarioFechou;
        }

        public OrdemServico() { }
    }
}
