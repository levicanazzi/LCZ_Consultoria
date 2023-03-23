using LCZ.Domain.Interfaces.IApplication;
using LCZ.Domain.Models;
using LCZ.Infra.Repository.Data;

namespace LCZ.Application.Services
{
    public class ContatoClienteAppService : ApplicationCore<ContatoCliente>, IContatoClienteAppService
    {
        public ContatoClienteAppService(AppDbContext db) : base(db)
        {
        }


    }
}
