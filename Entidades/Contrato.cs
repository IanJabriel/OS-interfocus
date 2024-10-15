using System;

namespace Interfocus.Models
{
    public class Contrato
    {
        public Guid Id { get; private set; }
        public Guid IdCliente { get; set; }
        public Guid IdEndereco { get; set; }
        public Guid IdEquipamento { get; set; }
        public int StatusContrato { get; set; }

        public Cliente Cliente { get; set; }

        public Contrato(Guid idCliente, Guid idEndereco, Guid idEquipamento, int statusContrato)
        {
            Id = Guid.NewGuid();
            IdCliente = idCliente;
            IdEndereco = idEndereco;
            IdEquipamento = idEquipamento;
            StatusContrato = statusContrato;
        }

        public Contrato() { }
    }
}