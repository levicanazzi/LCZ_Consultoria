using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LCZ.Domain.Interfaces.IApplication
{
    public interface IApplication <T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        ICollection<T> GetAll();
        T Get(int id);
        
    }
}
