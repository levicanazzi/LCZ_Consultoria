using LCZ.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCZ.Domain.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string Site { get; set; }
        public string Telefone { get; set; }
        public string RamoAtuacao { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string SituacaoCadastral { get; set; }
        public TipoClienteStatus TipoCliente { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public virtual List<ContatoCliente> ContatosCliente { get; set; }
        public Cliente()
        {
            
        }
        public Cliente(string cnpj, string razaoSocial, string nomeFantasia,
            string inscricaoEstadual, TipoClienteStatus tipoCliente, string cep, string endereco,
            string numero, string complemento, string cidade, string uf, List<ContatoCliente> contatos)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            SituacaoCadastral = inscricaoEstadual;
            TipoCliente = tipoCliente;
            Cep = cep;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Uf = uf;
            ContatosCliente = contatos;
        }
    }
}
