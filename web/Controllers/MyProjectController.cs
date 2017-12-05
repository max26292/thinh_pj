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
            using(mydatabase db = new mydatabase())
            {
                List<Item> itemlist = new List<Item>();
                
                itemlist = db.Items.Where(x => x.Category_id == 1).ToList();
                return View(itemlist);
            }
            
            
            

        }
        public ActionResult baycho()
        {

            using (mydatabase db = new mydatabase())
            {
                List<Item> itemlist = new List<Item>();
                itemlist = db.Items.Where(x => x.Category_id == 2).ToList();
                return View(itemlist);
            }




        }
        public ActionResult muoisaucho()
        {
            using (mydatabase db = new mydatabase())
            {
                List<Item> itemlist = new List<Item>();

                itemlist = db.Items.Where(x => x.Category_id == 3).ToList();
                return View(itemlist);
            }


        }
        public ActionResult haichincho()
        {
            using (mydatabase db = new mydatabase())
            {
                List<Item> itemlist = new List<Item>();

                itemlist = db.Items.Where(x => x.Category_id == 4).ToList();
                return View(itemlist);
            }


        }
        public ActionResult nammuoicho()
        {
            using (mydatabase db = new mydatabase())
            {
                List<Item> itemlist = new List<Item>();

                itemlist = db.Items.Where(x => x.Category_id == 5).ToList();
                return View(itemlist);
            }


        }
        public ActionResult news()
        {
            using (mydatabase db = new mydatabase())
            {
                return View(db.Items.ToList());
                //return View("Home");

            }

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
        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
       
    }
}