using System;

namespace ApiCrud.src.Entidades
{
    public class Contrato
    {
        public int Id { get; private set; }
        public int IdCliente { get; set; }
        public int IdEndereco { get; set; }
        public int IdEquipamento { get; set; }
        public int StatusContrato { get; set; }

        public Cliente Cliente { get; set; }

        public Contrato(int idCliente, int idEndereco, int idEquipamento, int statusContrato)
        {
            Id = Id;
            IdCliente = idCliente;
            IdEndereco = idEndereco;
            IdEquipamento = idEquipamento;
            StatusContrato = statusContrato;
        }

        public Contrato() { }
    }
}