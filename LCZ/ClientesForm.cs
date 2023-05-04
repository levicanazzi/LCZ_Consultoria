using LCZ.Domain.Interfaces;
using LCZ.Domain.Interfaces.IRepository;
using LCZ.Domain.Models;
using LCZ.Domain.Models.Enums;
using LCZ.Entities;
using Refit;
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
                SituacaoCadastral = txtSituacaoCadastral.Text,
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
            cliente.SituacaoCadastral = txtSituacaoCadastral.Text;
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
            if (idCliente == null)
            {
                MessageBox.Show("Nenhum cliente selecionado!");
            }
            else if (idCliente != null)
            {
                var cliente = _clienteRepo.FirstOrDefault(x => x.Id == idCliente);

                if (MessageBox.Show($"Deseja excluir o cliente {cliente.NomeFantasia}?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    _clienteRepo.Remove(cliente);
                    _clienteRepo.Save();
                    LimparCamposCliente();
                }
            }
        }
        private void BtnAddContato_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Nenhum cliente selecionado!");
            }
            else
            {

                var idCliente = int.Parse(txtId.Text);

                if (idCliente == null)
                {
                    MessageBox.Show("Nenhum cliente selecionado!");
                }
                else if (idCliente != null)
                {
                    var cliente = new Cliente();

                    cliente = _clienteRepo.FirstOrDefault(x => x.Id == idCliente);

                    if (cliente != null)
                    {
                        SexoStatus sexoStatus = (SexoStatus)cmbSexo.SelectedItem;
                        ContatoParaStatus contatoPara = (ContatoParaStatus)cmbContatoPara.SelectedItem;
                        TipoContatoStatus tipoContato = (TipoContatoStatus)cmbTipoContato.SelectedItem;

                        var contatoCliente = new ContatoCliente()
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
                            Observacoes = txtHistorico.Text,
                            Cliente = cliente,
                            IdCliente = idCliente
                        };

                        _contatoClienteRepo.Add(contatoCliente);
                        _contatoClienteRepo.Save();
                    }
                    else
                    {
                        MessageBox.Show("Não é possivel adicionar um contato sem um cliente selecionado.");
                    }
                }
            }
        }

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
                txtSituacaoCadastral.Text = cliente.SituacaoCadastral;
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
                Application.Run(new FormPesquisa(cliente, _clienteRepo, _contatoClienteRepo));
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
            txtSituacaoCadastral.Text = "";
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

        private void txtCep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarCep(txtCep.Text);
            }
        }

        async Task BuscarCep(string cep)
        {
            try
            {
                var cepBuscar = RestService.For<ICepApiService>("https://viacep.com.br/");

                var endereco = await cepBuscar.GetAddressAsync(cep);

                txtEndereco.Text = endereco.Logradouro;
                txtCidade.Text = endereco.Localidade;
                txtComplemento.Text = endereco.Complemento;
                txtUf.Text = endereco.Uf;
            }
            catch (Exception e)
            {
                MessageBox.Show("Falha! \n" + e);
            }
        }

        private void txtCnpj_Leave(object sender, EventArgs e)
        {
            BuscarCnpj(txtCnpj.Text);
        }

        async Task BuscarCnpj(string cnpj)
        {
            try
            {
                var receitaWSApi = RestService.For<IReceitaWSApi>("https://www.receitaws.com.br/v1/cnpj/");

                var cnpjResponse = await receitaWSApi.GetCnpjAsync(cnpj);


                txtSite.Text = cnpjResponse.Site;
                txtTelefone.Text = cnpjResponse.Telefone;
                txtSituacaoCadastral.Text = cnpjResponse.Situacao;
                txtCnpj.Text = cnpjResponse.Cnpj;
                txtNomeFantasia.Text = cnpjResponse.Fantasia;
                txtRazaoSocial.Text = cnpjResponse.Nome;
                txtCep.Text = cnpjResponse.Cep;
                txtEndereco.Text = cnpjResponse.Logradouro;
                txtNumero.Text = cnpjResponse.Numero;
                txtCidade.Text = cnpjResponse.Municipio;
                txtComplemento.Text = cnpjResponse.Complemento;
                txtUf.Text = cnpjResponse.Uf;

                if (cnpjResponse.Situacao == "ATIVA")
                {
                    cmbTipoCliente.SelectedIndex = 0;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Falha! \n" + e);
            }
        }
    }
}

