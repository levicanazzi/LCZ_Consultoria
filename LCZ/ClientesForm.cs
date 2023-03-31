using LCZ.Domain.Interfaces.IRepository;
using LCZ.Domain.Models;
using LCZ.Domain.Models.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LCZ
{
    public partial class ClientesForm : Form
    {
        public List<ContatoCliente> _contatos { get; set; }

        IClienteRepository _clienteRepo;
        IContatoClienteRepository _contatoClienteRepo;
        public ClientesForm(IClienteRepository clienteRepo, IContatoClienteRepository contatoClienteRepo)
        {
            _contatos = new List<ContatoCliente>();
            _contatoClienteRepo = contatoClienteRepo;
            _clienteRepo = clienteRepo;
            InitializeComponent();

            cmbSexo.Items.AddRange(Enum.GetValues(typeof(SexoStatus)).Cast<object>().ToArray());
            cmbContatoPara.Items.AddRange(Enum.GetValues(typeof(ContatoParaStatus)).Cast<object>().ToArray());
            cmbTipoCliente.Items.AddRange(Enum.GetValues(typeof(TipoClienteStatus)).Cast<object>().ToArray());
            cmbTipoContato.Items.AddRange(Enum.GetValues(typeof(TipoContatoStatus)).Cast<object>().ToArray());
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            TipoClienteStatus tipoCliente = (TipoClienteStatus)cmbTipoCliente.SelectedItem;

            _clienteRepo.Add(new Cliente()
            {
                Cnpj = TxtCnpj.Text,
                RazaoSocial = TxtRazaoSocial.Text,
                NomeFantasia = TxtNomeFantasia.Text,
                InscricaoEstadual = int.Parse(TxtInscricaoEstadual.Text),
                TipoCliente = tipoCliente,
                Cep = TxtCep.Text,
                Endereco = TxtEndereco.Text,
                Numero = int.Parse(TxtNumero.Text),
                Complemento = TxtComplemento.Text,
                Cidade = TxtCidade.Text,
                Uf = TxtUf.Text,
                ContatosCliente = _contatos
            });

            _clienteRepo.Save();
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            CarregarComboBox();
        }
        private void BtnAddContato_Click(object sender, EventArgs e)
        {
            SexoStatus sexoStatus = (SexoStatus)cmbSexo.SelectedItem;
            ContatoParaStatus contatoPara = (ContatoParaStatus)cmbContatoPara.SelectedItem;
            TipoContatoStatus tipoContato = (TipoContatoStatus)cmbTipoContato.SelectedItem;

            _contatoClienteRepo.Add(new ContatoCliente()
            {
                Nome = TxtNome.Text,
                Cargo = TxtCargo.Text,
                Sexo = sexoStatus,
                Aniversario = DateTime.Parse(TxtAniversario.Text),
                Celular1 = TxtCelular1.Text,
                Celular2 = TxtCelular2.Text,
                Whatsapp = TxtWhatsapp.Text,
                Email = TxtEmail.Text,
                Departamento = TxtDepartamento.Text,
                TipoContato = tipoContato,
                ContatoPara = contatoPara,
                Observacoes = TxtObservacoes.Text
            });
            _contatoClienteRepo.Save();

        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Id do cliente selecionado

            if (cmbPesquisar.SelectedValue is not null)
            {
                AutoCompletarCampos();
            }



            //int cmbPrenchida = cmbPesquisar.SelectedIndex;
            //if (cmbPrenchida != -1)
            //{
            //    using (SqlConnection connection = new SqlConnection("Server = localhost; Database = LCZ; Trusted_Connection = True;"))
            //    {
            //        connection.Open();
            //        string sql = "SELECT Cep, Cnpj FROM Clientes WHERE Nome = @NomeSelecionado";
            //        using (SqlCommand command = new SqlCommand(sql, connection))
            //        {
            //            command.Parameters.AddWithValue("@NomeSelecionado", cmbPesquisar.SelectedItem.ToString());
            //            using (SqlDataReader reader = command.ExecuteReader())
            //            {
            //                if (reader.Read())
            //                {
            //                    TxtCep.Text = reader["Cep"].ToString();
            //                    TxtCnpj.Text = reader["Cnpj"].ToString();
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void AutoCompletarCampos()
        {
            var idCliente = int.Parse(cmbPesquisar.SelectedValue.ToString());

            var cliente = _clienteRepo.FirstOrDefault(x => x.Id == idCliente);

            if (cliente != null)
            {
                TxtCnpj.Text = cliente.Cnpj;
            }
        }

        private void CarregarComboBox()
        {
            var clientes = _clienteRepo.GetAll();

            var bindingSource = new BindingSource();
            bindingSource.DataSource = clientes;

            cmbPesquisar.SelectedIndexChanged -= new EventHandler(cmbClientes_SelectedIndexChanged);

            cmbPesquisar.DataSource = bindingSource.DataSource;
            cmbPesquisar.DisplayMember = "NomeFantasia";
            cmbPesquisar.ValueMember = "Id";

            cmbPesquisar.SelectedIndexChanged += new EventHandler(cmbClientes_SelectedIndexChanged);

        }
    }

}

