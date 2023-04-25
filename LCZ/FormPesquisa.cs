using LCZ.Domain.Interfaces.IRepository;
using LCZ.Domain.Models;
using System.Data;
using System.Threading;

namespace LCZ
{
    public partial class FormPesquisa : Form
    {
        Thread td2;
        public IEnumerable<Cliente> Cliente { get; set; }
        IClienteRepository _clienteRepo;
        IContatoClienteRepository _contatoClienteRepo;


        public FormPesquisa(IEnumerable<Cliente> cliente, IClienteRepository clienteRepo)
        {
            InitializeComponent();
            Cliente = cliente;
            _clienteRepo = clienteRepo;
        }

        private void FormPesquisa_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        public void CarregarGrid()
        {
            var cliente = this.Cliente;

            var columns = from t in cliente
                          orderby t.NomeFantasia
                          select new
                          {
                              t.Id,
                              t.Cnpj,
                              t.NomeFantasia,
                              t.RazaoSocial,
                              t.Cidade,
                              t.Uf
                          };


            var bindingSource = new BindingSource();
            bindingSource.DataSource = columns.ToList();

            gdvPesquisa.DataSource = bindingSource;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            td2 = new Thread(AbrirNovaJanela);
            td2.SetApartmentState(ApartmentState.STA);
            td2.Start();
            this.Hide();
        }

        private void gdvPesquisa_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
            }
            else
            {
                DataGridViewRow linha = gdvPesquisa.Rows[e.RowIndex];

                txtId.Text = linha.Cells[0].Value.ToString();
            }
        }
        public void AbrirNovaJanela(object obj)
        {
            var idCliente = int.Parse(txtId.Text);
            var cliente = _clienteRepo.FirstOrDefault(x => x.Id == idCliente);

            Application.Run(new ClientesForm(_clienteRepo, _contatoClienteRepo, cliente));
        }
    }
}
