using LCZ.Domain.Interfaces.IApplication;
using LCZ.Domain.Interfaces.IRepository;
using LCZ.Infra.Repository;
using LCZ.Infra.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCZ.Application.Services
{
    public class ApplicationCore<T> : Repository<T>, IApplication<T> where T : class
    {
        public ApplicationCore(AppDbContext db) : base(db)
        {
        }

        public void Delete(T entity)
        {
            this.Delete(entity);
        }

        public T Get(int id)
        {
            return this.Get(id);
        }

        public ICollection<T> GetAll()
        {
            return this.GetAll();
        }

        public virtual void Insert(T entity)
        {
            this.Add(entity);
            this.Save();
        }

        public void Update(T entity)
        {
            this.Update(entity);
            this.Save();
        }
    }
}
