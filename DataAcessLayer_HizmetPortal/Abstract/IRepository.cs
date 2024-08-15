using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer_HizmetPortal.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        List<T> FiltreList(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        void Add(T p);
        void Delete(T p);
        void Update(T p);
        
    }
}
