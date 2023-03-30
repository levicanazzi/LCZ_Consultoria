using LCZ.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LCZ.Domain.Models
{
    public class ContatoCliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public SexoStatus Sexo { get; set; }
        public DateTime Aniversario { get; set; }
        public string Departamento { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Whatsapp { get; set; }
        public string Email { get; set; }
        public TipoContatoStatus TipoContato { get; set; }
        public ContatoParaStatus ContatoPara { get; set; }
        public string Observacoes { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int IdCliente { get; set; }
        public ContatoCliente()
        {
            
        }
        public ContatoCliente(int id, string nome, string cargo, SexoStatus sexo, 
            DateTime aniversario, string departamento, string celular1, string celular2, 
            string whatsapp, string email, TipoContatoStatus tipoContato, ContatoParaStatus contatoPara, string observacoes, int idCliente)
        {
            Id = id;
            Nome = nome;
            Cargo = cargo;
            Sexo = sexo;
            Aniversario = aniversario;
            Departamento = departamento;
            Celular1 = celular1;
            Celular2 = celular2;
            Whatsapp = whatsapp;
            Email = email;
            TipoContato = tipoContato;
            ContatoPara = contatoPara;
            Observacoes = observacoes;
            IdCliente = idCliente;
        }
    }
}