using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.DAL
{
    public class BaseDAL<T> where T : class, new()
    {
        /// <summary>
        /// 上下文对象
        /// </summary>
        private DbContext dbContext = DbContextFactory.Create();
        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().AddOrUpdate(entity);
        }

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda);
        }
        public IQueryable<T> GetEntities<type>(int pageSize,int pageIndex,bool isAse,Expression<Func<T,bool>> whereLambda,Expression<Func<T,type>> orderBy)
        {
            if (isAse)
            {
                return dbContext.Set<T>().Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return dbContext.Set<T>().Where(whereLambda).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }
        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }
    }
}
