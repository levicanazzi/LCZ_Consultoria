using LCZ.Domain.Interfaces.IRepository;
using LCZ.Domain.Models;
using System.Data;

namespace LCZ
{
    public partial class FormPesquisa : Form
    {
        //private Cliente cliente;        
        public Cliente Cliente { get; set; }
        public IClienteRepository _clienteRepo { get; set; }
        public FormPesquisa(Cliente cliente, IClienteRepository clienteRepo)
        {
            InitializeComponent();
            Cliente = cliente;
            _clienteRepo = clienteRepo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        public void CarregarGrid()
        {
            Cliente cliente = new Cliente();

            cliente = this.Cliente;

            var clientes = _clienteRepo.GetAll(x => x.NomeFantasia.Contains(cliente.NomeFantasia)).ToList();

            var columns = from t in clientes
                          orderby t.NomeFantasia
                          select new
                          {
                              Cnpj = t.Cnpj,
                              NomeFantasia = t.NomeFantasia,
                              RazaoSocial = t.RazaoSocial,
                              Cidade = t.Cidade,
                              Uf = t.Uf
                          };


            var bindingSource = new BindingSource();
            bindingSource.DataSource = columns.ToList();

            dtGriPesquisa.DataSource = bindingSource;
        }

    }
}
