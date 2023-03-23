using LCZ.Domain.Interfaces.IRepository;
using LCZ.Domain.Models;

namespace LCZ.Infra.Repository.Data.Entities
{
    public class ContatoClienteRepository : Repository<ContatoCliente>, IContatoClienteRepository
    {
        public ContatoClienteRepository(AppDbContext db) : base(db)
        {
        }
    }
}
