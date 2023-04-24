
using LCZ.Domain.Interfaces.IRepository;

namespace LCZ
{
    public partial class Login : Form
    {
        Thread nt;
        IClienteRepository _clienteRepo;
        IContatoClienteRepository _contatoClienteRepo;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
        }

        private void gerarForm(object? obj)
        {
            Application.Run(new ClientesForm(_clienteRepo, _contatoClienteRepo));
        }
    }
}
