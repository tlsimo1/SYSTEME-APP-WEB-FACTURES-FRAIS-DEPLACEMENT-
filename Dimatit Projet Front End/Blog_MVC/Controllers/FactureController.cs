using Blog_MVC.Helps;
using Blog_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Blog_MVC.Controllers
{
    public class FactureController : Controller
    {
        public IActionResult Index(string roles, string userName)
        {
            string[] arrry = { };
            GetUserInfo_ViewModel userInfo = new GetUserInfo_ViewModel();
            try
            {
                if (userName == null)
                {
                    userInfo = GlobalVariable.G_UserInfo;
                    return View(userInfo);
                }
                userInfo.UserName = userName == null ? "" : userName;
                userInfo.Roles = roles == null ? arrry : roles.Split(',');
                GlobalVariable.G_UserInfo = userInfo;
                return View(userInfo);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpGet]
       
        public IActionResult Create(string roles, string userName)
        {
            GetUserInfo_ViewModel userInfo = new GetUserInfo_ViewModel();
            if (userName == null)
            {
                userInfo = GlobalVariable.G_UserInfo;
                return View(userInfo);
            }
            userInfo.UserName = userName;
            userInfo.Roles = roles.Split(',');
            GlobalVariable.G_UserInfo = userInfo;
            return View(userInfo);
        }
        [HttpGet]
        public IActionResult Consultation(string roles, string userName)
        {
            GetUserInfo_ViewModel userInfo = new GetUserInfo_ViewModel();
            if (userName == null)
            {
                userInfo = GlobalVariable.G_UserInfo;
                return View(userInfo);
            }
            userInfo.UserName = userName;
            userInfo.Roles = roles.Split(',');
            GlobalVariable.G_UserInfo = userInfo;
            return View(userInfo);
        }
        
        
    }
}
