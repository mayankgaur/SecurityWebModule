using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityWebModule.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        List<T> GetAll();
        T GetbyID(int ID);
        void Create(T model);
        void Update(T model);
        void Delete(T objRecord);
    }
}
