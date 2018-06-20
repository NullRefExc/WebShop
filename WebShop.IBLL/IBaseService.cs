using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.IBLL
{
    public interface IBaseService<T> where T : class, new()
    {
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetEntities<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> orderLambda, Expression<Func<T, bool>> whereLambda);
    }
}
