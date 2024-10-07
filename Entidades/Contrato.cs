using System;

namespace Interfocus.Models
{
    public class Contrato
    {
        public Guid Id { get; private set; }
        public Guid IdCliente { get; set; }
        public int IdEndereco { get; set; }
        public int IdEquipamento { get; set; }
        public int StatusContrato { get; set; }

        public Cliente Cliente { get; set; }
    }
}
