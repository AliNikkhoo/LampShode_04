using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_FrameWork.Domain
{
   public interface IRepository<TKey,T> where T :class
    {
        T Get(TKey Id);
        List<T> Get();
        void Creat(T entity);
        bool Exists(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
