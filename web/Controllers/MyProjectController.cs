using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Data.Entity;
using web.Models;

namespace web.Controllers
{
    public class MyProjectController : Controller
    {
        // GET: MyProject
        public ActionResult Index()
        {

            using (mydatabase db = new mydatabase())
            {
                return View(db.Users.ToList());
                //return View("Home");

            }

        }
        public ActionResult boncho()
        {
            return View();

        }
        public ActionResult baycho()
        {
            return View();

        }
        public ActionResult muoisaucho()
        {
            return View();

        }
        public ActionResult haichincho()
        {
            return View();

        }
        public ActionResult nammuoicho()
        {
            return View();

        }
        public ActionResult news()
        {
            return View();

        }
       //register
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register (User user )
        {
            if (ModelState.IsValid)
               
            {
                var confirm = 0;
                using (mydatabase adduser = new mydatabase() )
                {
                    
                    if(user.password == user.confirmpassword)
                    {
                        var check = adduser.Users.Where(u => u.username == user.username).Count();
                        
                        if(check == 0)
                        {
                            adduser.Users.Add(user);
                            adduser.SaveChanges();
                            confirm = 1;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Username exists!!!");
                        }
                       
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password and Confirm password is not same!!!");
                    }
                    
                }
                if(confirm == 1)
                {
                    ModelState.Clear();
                    ViewBag.Message = user.username + " đăng kí thành công!";
                    return RedirectToAction("login");
                }
               
            }                                      
            return View();
        }
       // login
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(User user)
        {
            using (mydatabase checkuser = new mydatabase())
            {
                var usr = checkuser.Users.Where(u => u.username == user.username && u.password == user.password).FirstOrDefault();
                if (usr != null)
                {
                    //Session["userID"] = usr.Id.ToString();
                    Session["UserName"] = usr.username.ToString();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }
            }
            return View();
        }
       
    }
}