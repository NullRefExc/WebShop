using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model;

namespace WebShop.DAL
{
    public class DbContextFactory
    {
        public static DbContext Create()
        {
            DbContext dbContext = CallContext.GetData("DbContext") as DbContext;
            if (dbContext == null)
            {
                dbContext = new ShopModel();
                CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;
        }
    }
}
