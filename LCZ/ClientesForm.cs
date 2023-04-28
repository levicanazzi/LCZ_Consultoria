using LCZ.Domain.Interfaces.IRepository;
using LCZ.Domain.Models;
using LCZ.Domain.Models.Enums;
using System.Data;
using System.Threading;

namespace LCZ
{
    public partial class ClientesForm : Form
    {
        Thread td1;
        public List<ContatoCliente> _contatos { get; set; }

        IClienteRepository _clienteRepo;
        IContatoClienteRepository _contatoClienteRepo;
        public Cliente Cliente { get; set; }

        public ClientesForm(IClienteRepository clienteRepo, IContatoClienteRepository contatoClienteRepo)
        {
            _contatos = new List<ContatoCliente>();
            _contatoClienteRepo = contatoClienteRepo;
            _clienteRepo = clienteRepo;


            InitializeComponent();
            CarregarComboBox();
        }

        public ClientesForm(IClienteRepository clienteRepo, IContatoClienteRepository contatoClienteRepo, Cliente cliente)
        {
            _contatos = new List<ContatoCliente>();
            _contatoClienteRepo = contatoClienteRepo;
            _clienteRepo = clienteRepo;
            Cliente = cliente;

            InitializeComponent();

            CarregarComboBox();
            CompletarCampos(cliente);
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {

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

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            var idCliente = int.Parse(txtId.Text);

            var cliente = _clienteRepo.FirstOrDefault(x => x.Id == idCliente);

            if (cliente == null)
            {
                MessageBox.Show("Não há cliente cadastrado no Banco.");
            }
            else
            {
                UpCliente(cliente);
            }
        }

        private void UpCliente(Cliente cliente)
        {
            cliente.Site = txtSite.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.RamoAtuacao = txtRamoAtuacao.Text;
            cliente.Cnpj = txtCnpj.Text;
            cliente.RazaoSocial = txtRazaoSocial.Text;
            cliente.NomeFantasia = txtNomeFantasia.Text;
            cliente.InscricaoEstadual = txtInscricaoEstadual.Text;
            cliente.TipoCliente = (TipoClienteStatus)cmbTipoCliente.SelectedItem;
            cliente.Cep = txtCep.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Numero = txtNumero.Text;
            cliente.Complemento = txtComplemento.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.Uf = txtUf.Text;

            _clienteRepo.Save();
            CompletarCampos(cliente);
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var idCliente = int.Parse(txtId.Text);

            var cliente = _clienteRepo.FirstOrDefault(x => x.Id == idCliente);

            if (MessageBox.Show($"Deseja excluir o cliente {cliente.NomeFantasia}?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                _clienteRepo.Remove(cliente);
                _clienteRepo.Save();
                LimparCamposCliente();
            }
            else
            {
                //return;
            }
        }

        //private void BtnAddContato_Click(object sender, EventArgs e)
        //{
        //    SexoStatus sexoStatus = (SexoStatus)cmbSexo.SelectedItem;
        //    ContatoParaStatus contatoPara = (ContatoParaStatus)cmbContatoPara.SelectedItem;
        //    TipoContatoStatus tipoContato = (TipoContatoStatus)cmbTipoContato.SelectedItem;

        //    _contatoClienteRepo.Add(new ContatoCliente()
        //    {
        //        Nome = txtNomeContato.Text,
        //        Cargo = txtCargo.Text,
        //        Sexo = sexoStatus,
        //        Aniversario = DateTime.Parse(txtAniversario.Text),
        //        Celular1 = txtCelular1.Text,
        //        Celular2 = txtCelular2.Text,
        //        Whatsapp = txtWhatsapp.Text,
        //        Email = txtEmail.Text,
        //        Departamento = txtDepartamento.Text,
        //        TipoContato = tipoContato,
        //        ContatoPara = contatoPara,
        //        Observacoes = txtHistorico.Text
        //    });
        //    _contatoClienteRepo.Save();

        //}

        private void CompletarCampos(Cliente cliente)
        {
            if (cliente != null)
            {
                txtId.Text = (cliente.Id).ToString();
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string pesquisa = txtPesquisar.Text;
            var cliente = _clienteRepo.GetAll(x => x.NomeFantasia.Contains(pesquisa)).ToList();

            if (cliente == null || txtPesquisar.Text == "")
            {
                MessageBox.Show("Não foi encontrado nenhum resultado na pesquisa.");

            }
            else
            {
                td1 = new Thread(AbrirJanelaPesquisa);
                td1.SetApartmentState(ApartmentState.STA);
                td1.Start();
                this.Hide();
            }
        }

        public void AbrirJanelaPesquisa(object obj)
        {
            string pesquisa = txtPesquisar.Text;
            var cliente = _clienteRepo.GetAll(x => x.NomeFantasia.Contains(pesquisa));
            if (cliente == null)
            {
                MessageBox.Show("Não foi encontrado nenhum resultado na pesquisa.");
            }
            else
            {                
                Application.Run(new FormPesquisa(cliente, _clienteRepo));
            }
        }

        private void LimparCamposCliente()
        {
            txtId.Text = "";
            txtPesquisar.Text = "";
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

        private void CarregarComboBox()
        {
            cmbSexo.Items.AddRange(Enum.GetValues(typeof(SexoStatus)).Cast<object>().ToArray());
            cmbContatoPara.Items.AddRange(Enum.GetValues(typeof(ContatoParaStatus)).Cast<object>().ToArray());
            cmbTipoCliente.Items.AddRange(Enum.GetValues(typeof(TipoClienteStatus)).Cast<object>().ToArray());
            cmbTipoContato.Items.AddRange(Enum.GetValues(typeof(TipoContatoStatus)).Cast<object>().ToArray());
        }

        private void ClientesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja Encerrar a Aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {

                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }

}

