using LCZ.Domain.Interfaces.IRepository;
using LCZ.Domain.Models;
using LCZ.Domain.Models.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
                Cnpj = txtCnpj.Text,
                Site = txtSite.Text,
                Telefone = txtTelefone.Text,
                RamoAtuacao = txtRamoAtuacao.Text,
                RazaoSocial = txtRazaoSocial.Text,
                NomeFantasia = txtNomeFantasia.Text,
                InscricaoEstadual = txtInscricaoEstadual.Text,
                TipoCliente = tipoCliente,
                Cep = txtCep.Text,
                Endereco = txtEndereco.Text,
                Numero = txtNumero.Text,
                Complemento = txtComplemento.Text,
                Cidade = txtCidade.Text,
                Uf = txtUf.Text,
                ContatosCliente = _contatos
            });

            _clienteRepo.Save();
            LimparCamposCliente();
        }

        private void LimparCamposCliente()
        {
            txtPesquisar.Text = "";
            cmbPesquisar.SelectedIndex = -1;
            txtSite.Text = "";
            txtTelefone.Text = "";
            txtRamoAtuacao.Text = "";
            txtCnpj.Text = "";
            txtRazaoSocial.Text = "";
            txtNomeFantasia.Text = "";
            txtInscricaoEstadual.Text = "";
            cmbTipoCliente.SelectedIndex = -1;
            txtCep.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtCidade.Text = "";
            txtUf.Text = "";
        }
        private void ClientesForm_Load(object sender, EventArgs e)
        {
            //CarregarComboBox();
        }
        private void BtnAddContato_Click(object sender, EventArgs e)
        {
            SexoStatus sexoStatus = (SexoStatus)cmbSexo.SelectedItem;
            ContatoParaStatus contatoPara = (ContatoParaStatus)cmbContatoPara.SelectedItem;
            TipoContatoStatus tipoContato = (TipoContatoStatus)cmbTipoContato.SelectedItem;

            _contatoClienteRepo.Add(new ContatoCliente()
            {
                Nome = txtNomeContato.Text,
                Cargo = txtCargo.Text,
                Sexo = sexoStatus,
                Aniversario = DateTime.Parse(txtAniversario.Text),
                Celular1 = txtCelular1.Text,
                Celular2 = txtCelular2.Text,
                Whatsapp = txtWhatsapp.Text,
                Email = txtEmail.Text,
                Departamento = txtDepartamento.Text,
                TipoContato = tipoContato,
                ContatoPara = contatoPara,
                Observacoes = txtHistorico.Text
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
                txtSite.Text = cliente.Site;
                txtTelefone.Text = cliente.Telefone;
                txtRamoAtuacao.Text = cliente.RamoAtuacao;
                txtCnpj.Text = cliente.Cnpj;
                txtRazaoSocial.Text = cliente.RazaoSocial;
                txtNomeFantasia.Text = cliente.NomeFantasia;
                txtInscricaoEstadual.Text = cliente.InscricaoEstadual;
                cmbTipoCliente.Text = cliente.TipoCliente.ToString();
                txtCep.Text = cliente.Cep;
                txtEndereco.Text = cliente.Endereco;
                txtNumero.Text = cliente.Numero;
                txtComplemento.Text = cliente.Complemento;
                txtCidade.Text = cliente.Cidade;
                txtUf.Text = cliente.Uf;
            }
        }

        private void CarregarComboBox()
        {
            string pesquisa = txtPesquisar.Text;

            var clientes = _clienteRepo.GetAll(x => x.NomeFantasia.Contains(pesquisa));

            var bindingSource = new BindingSource();
            bindingSource.DataSource = clientes;

            cmbPesquisar.SelectedIndexChanged -= new EventHandler(cmbClientes_SelectedIndexChanged);

            cmbPesquisar.DataSource = bindingSource.DataSource;
            cmbPesquisar.DisplayMember = "NomeFantasia";
            cmbPesquisar.ValueMember = "Id";

            cmbPesquisar.SelectedIndexChanged += new EventHandler(cmbClientes_SelectedIndexChanged);

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarComboBox();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var idCliente = int.Parse(cmbPesquisar.SelectedValue.ToString());

            var cliente = _clienteRepo.FirstOrDefault(x => x.Id == idCliente);

            _clienteRepo.Remove(cliente);
            _clienteRepo.Save();

            LimparCamposCliente();
        }
    }

}

