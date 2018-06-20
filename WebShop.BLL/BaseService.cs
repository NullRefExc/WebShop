using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebShop.IDAL;

namespace WebShop.BLL
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IBaseDAL<T> Dal { get; set; }
        public abstract void SetDal();
        public BaseService()
        {
            SetDal();
        }

        public bool Add(T enitiy)
        {
            Dal.Add(enitiy);
            return Dal.SaveChanges();
        }

        public bool Delete(T entity)
        {
            Dal.Delete(entity);
            return Dal.SaveChanges();
        }

        public bool Update(T entity)
        {
            Dal.Update(entity);
            return Dal.SaveChanges();
        }
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetEntities(whereLambda);
        }

        public IQueryable<T> GetEntities<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetEntities(pageIndex, pageSize, isAsc, whereLambda, orderByLambda);
        }
    }
}
