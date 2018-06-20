using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model;
using WebShop.IBLL;
using WebShop.IDAL;

namespace WebShop.BLL
{
    public class UserService : BaseService<SysUser>, IUserService
    {
        private IUserDAL userDal = DALContainer.Container.Resolve<IUserDAL>();
        public override void SetDal()
        {
            Dal = userDal;
        }
    }
}
