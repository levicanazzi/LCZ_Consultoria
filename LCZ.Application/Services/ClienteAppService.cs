using LCZ.Domain.Interfaces.IApplication;
using LCZ.Domain.Models;
using LCZ.Infra.Repository.Data;

namespace LCZ.Application.Services
{
    public class ClienteAppService : ApplicationCore<Cliente>, IClienteAppService
    {
        public ClienteAppService(AppDbContext db) : base(db)
        {
        }

        public override void Insert(Cliente entity)
        {
            if (entity == null)
            {
                throw new Exception("Cliente vazio.");
            }
            else if (entity.Name.Length <= 10)
            {
                throw new Exception("O nome do cliente tem que ter mais de dez caracteres.");
            }
            else if (ValidaCpfCnpj(entity.CpfCnpj) == false)
            {
                throw new Exception("O nome do cliente tem que ter mais de dez caracteres");
            }
           base.Insert(entity); 
            //this.Insert(entity);
        }

        private bool ValidaCpfCnpj(string? cpfCnpj)
        {
            return true;
        }


    }
}
