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
        IClienteAppService _clienteAppService;
        public ClientesForm(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _clienteAppService.Insert(new Cliente()
            {
                Name = "Ulisses",
                CpfCnpj = "4685469"
            });
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
