using Blog_MVC.Helps;
using Blog_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog_MVC.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult LogIn(string roles, string userName)
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

        //[HttpPost]
        //public IActionResult LogOut()
        //{
        //    //Delete the Cookie from Browser.
        //    Response.Cookies.Delete("token");
        //    //return RedirectToAction("Achat", "Achat");
        //    //return RedirectToRoute(new { action = "Achat", controller = "Achat", area = "" });
        //    //return RedirectToAction("LogIn");
        //    //LocalRedirect("/Home/Index");
        //    return View();
        //}

        //public IActionResult Revoke([FromBody] RevokeRequest request)
        //{
        //    if (RefreshTokens.ContainsKey(request.RefreshToken))
        //    {
        //        // Remove the refresh token to revoke it
        //        RefreshTokens.Remove(request.RefreshToken);
        //        return Ok("Token revoked successfully");
        //    }
        //    return BadRequest("Invalid refresh token");
        //}
        public IActionResult PageNotFound()
        {
            
            return View();
        }
    }
}
