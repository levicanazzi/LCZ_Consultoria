using LCZ.Domain.Interfaces.IApplication;
using LCZ.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCZ
{
    public partial class ClientesForm : Form
    {
        public List<ContatoCliente> _contatos { get; set; }

        IClienteAppService _clienteAppService;
        IContatoClienteAppService _contatoClienteAppService;
        public ClientesForm(IClienteAppService clienteAppService, IContatoClienteAppService contatoClienteAppService)
        {
            _contatos = new List<ContatoCliente>();
            _contatoClienteAppService = contatoClienteAppService;
            _clienteAppService = clienteAppService;
            InitializeComponent();

        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            _clienteAppService.Insert(new Cliente()
            {
                Cnpj = TxtCnpj.Text,
                RazaoSocial = TxtRazaoSocial.Text,
                NomeFantasia = TxtNomeFantasia.Text,
                InscricaoEstadual = int.Parse(TxtInscricaoEstadual.Text),
                DataFundacao = DateTime.Parse(TxtDataFundacao.Text),
                Cep = TxtCep.Text,
                Endereco = TxtEndereco.Text,
                Numero = int.Parse(TxtNumero.Text),
                Complemento = TxtComplemento.Text,
                Cidade = TxtCidade.Text,
                Uf = TxtUf.Text,
                ContatosCliente = _contatos
            });
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnAddContato_Click(object sender, EventArgs e)
        {
            _contatoClienteAppService.Insert(new ContatoCliente()
            {
                Nome = TxtNome.Text,
                Cargo = TxtCargo.Text,
                Sexo = TxtSexo.Text,
                Aniversario = DateTime.Parse(TxtAniversario.Text),
                Celular1 = TxtCelular1.Text,
                Celular2 = TxtCelular2.Text,
                Whatsapp = TxtWhatsapp.Text,
                Email = TxtEmail.Text,
                Departamento = TxtDepartamento.Text,
                TipoContato = TxtTipoContato.Text,
                ResusltadoObtido = TxtResultadoObtido.Text,
                Observacoes = TxtObservacoes.Text
            });

            //_contatos.Add(contato);
        }
    }
}
