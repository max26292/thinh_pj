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
        public ActionResult cpanel(int ?id)
        {
            return View();
        }
        public ActionResult boncho()
        {
            using(mydatabase db = new mydatabase())
            {
                //List<Item> itemlist = new List<Item>();

                //itemlist = db.Items.Where(x => x.Category_id == 1).ToList();
                var itemlist = db.Items.Where(x=> x.Category_id ==1).ToList();
                var category_item = db.Categories.Where(x=> x.Id ==1);
                var List = new data_return_car();
                List.items = itemlist;
                List.category_eachitem = category_item.Single();
                return View(List);
            }
            
            
            

        }
        public ActionResult baycho()
        {

            using (mydatabase db = new mydatabase())
            {
                var itemlist = db.Items.Where(x => x.Category_id == 2).ToList();
                var category_item = db.Categories.Where(x => x.Id == 2);
                var List1 = new data_return_car();
                List1.items = itemlist;
                List1.category_eachitem = category_item.Single();
                return View(List1);
            }




        }
        public ActionResult muoisaucho()
        {
            using (mydatabase db = new mydatabase())
            {
                var itemlist = db.Items.Where(x => x.Category_id == 3).ToList();
                var category_item = db.Categories.Where(x => x.Id == 3);
                var List2 = new data_return_car();
                List2.items = itemlist;
                List2.category_eachitem = category_item.Single();
                return View(List2);
            }


        }
        public ActionResult haichincho()
        {
            using (mydatabase db = new mydatabase())
            {
                var itemlist = db.Items.Where(x => x.Category_id == 4).ToList();
                var category_item = db.Categories.Where(x => x.Id == 4);
                var List3= new data_return_car();
                List3.items = itemlist;
                List3.category_eachitem = category_item.Single();
                return View(List3);
            }


        }
        public ActionResult nammuoicho()
        {
            using (mydatabase db = new mydatabase())
            {
                var itemlist = db.Items.Where(x => x.Category_id == 5).ToList();
                var category_item = db.Categories.Where(x => x.Id == 5);
                var List4 = new data_return_car();
                List4.items = itemlist;
                List4.category_eachitem = category_item.Single();
                return View(List4);
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
                    Session["User_role"] = usr.role.ToString();
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