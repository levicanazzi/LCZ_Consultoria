using LCZ.Application.Services;
using LCZ.Domain.Interfaces.IApplication;
using LCZ.Domain.Interfaces.IRepository;
using LCZ.Infra.Repository.Data;
using LCZ.Infra.Repository.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.Design;
using System.Configuration;
using System.Windows.Forms;

namespace LCZ
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // Cria o objeto HostBuilder
            var builder = Host.CreateDefaultBuilder();

            // Configura a injeção de dependência
            builder.ConfigureServices((hostContext, services) =>
            {
                string sCon = "Server=localhost;Database=LCZ;Trusted_Connection=True;";

                services.AddDbContext<AppDbContext>(options =>
                   options.UseSqlServer(sCon));

                services.AddTransient<IClienteRepository, ClienteRepository>();
                services.AddTransient<IClienteAppService, ClienteAppService>();
                services.AddTransient<IContatoClienteRepository, ContatoClienteRepository>();
                services.AddTransient<IContatoClienteAppService, ContatoClienteAppService>();
                services.AddTransient<ClientesForm>();
            });

            // Cria um provedor de serviços a partir do objeto HostBuilder
            using var host = builder.Build();
            using var serviceScope = host.Services.CreateScope();
            var services = serviceScope.ServiceProvider;

            // Resolve o serviço MyForm a partir do provedor de serviços
            var form = services.GetRequiredService<ClientesForm>();

            System.Windows.Forms.Application.Run(form);
        }

    }
}