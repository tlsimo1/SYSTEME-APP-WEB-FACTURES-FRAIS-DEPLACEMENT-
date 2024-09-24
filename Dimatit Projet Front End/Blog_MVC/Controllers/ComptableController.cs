using Blog_MVC.Helps;
using Blog_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog_MVC.Controllers
{
    public class ComptableController : Controller
    {
        

        public IActionResult Comptable(string roles, string userName)
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
    }
}
