using Deloitte.Business.Interface;
using Deloitte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Deloitte.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private readonly IUserBusiness _userBusiness;
        public LoginController(
           IUserBusiness userBusiness
           )
        {
            _userBusiness = userBusiness;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserViewModel request)
        {
            var result = _userBusiness.ValidateUser(request);

            if (result == null)
                RedirectToAction("Index");

            return RedirectToAction("Index", "Home", new { UserId = result.Id });
        }
    }
}