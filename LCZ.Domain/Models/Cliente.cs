using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCZ.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CpfCnpj { get; set; }

        public Cliente()
        {
            
        }

        public Cliente(int id, string name, string cpfCnpj)
        {
            Id = id;
            Name = name;
            CpfCnpj = cpfCnpj;
        }
    }
}
