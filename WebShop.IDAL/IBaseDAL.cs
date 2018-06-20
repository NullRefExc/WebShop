using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.IDAL
{
    public interface IBaseDAL<T> where T:class,new()
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns></returns>
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="type">排序类型</typeparam>
        /// <param name="pageIndex">分页索引</param>
        /// <param name="pageSize">分页长度</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="whereLambda">条件表达式</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <returns></returns>
        IQueryable<T> GetEntities<type>(int pageIndex, int pageSize, bool isAsc, Expression<Func<T, bool>> whereLambda, Expression<Func<T, type>> orderLambda);
        /// <summary>
        /// 保存上下文
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
