using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.IBLL;
using System.Data.Entity.SqlServer;

namespace WebShop.App.Controllers
{
    public class HomeController : Controller
    {
        private IUserService UserService = BLLContainer.Container.Resolve<IUserService>();
        // GET: Home
        public ActionResult Index()
        {
            WebShop.Model.SysUser sysUser = UserService.GetEntities(u => true).SingleOrDefault();
            string sysCompany = sysUser.Company.CompanyName;
            return View();
        }
    }
}