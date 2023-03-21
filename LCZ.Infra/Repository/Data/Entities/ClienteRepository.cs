using LCZ.Domain.Interfaces.IRepository;
using LCZ.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCZ.Infra.Repository.Data.Entities
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext db) : base(db)
        {
        }
    }
}
