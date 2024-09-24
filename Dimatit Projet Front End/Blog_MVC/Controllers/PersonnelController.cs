using Blog_MVC.Helps;
using Blog_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Reflection;

namespace Blog_MVC.Controllers
{
    public class PersonnelController : Controller
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
        //[HttpPost]
        //public IActionResult GetInfoUser([FromBody] dynamic data)
        //{
        //    //JavaScriptSerializer js = new JavaScriptSerializer();
        //    var dat = JsonConvert.DeserializeObject<dynamic>(data.ToString());
            
        //    GetUserInfo_ViewModel userInfo=new GetUserInfo_ViewModel();
        //    userInfo.UserName = dat["username"];
        //    userInfo.Roles = dat["roles"];
        //    //string[] Roles= userInfo.Roles.Split(',');
        //    //userInfo.Roles= String.Join(",", dat["roles"]);

        //    return Json(userInfo);
        //}
        
    }
}
