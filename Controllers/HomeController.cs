using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quoting_dojo.Models;
using DbConnection;

namespace quoting_dojo.Controllers
{
    public class HomeController : Controller
    {
        private Context dbContext;
 
        // here we can "inject" our context service into the constructor
        public YourController(Context context)
        {
            dbContext = context;
        }

        public ViewResult Index()
        {
            return View();
        }
        [HttpGet("all-quotes")]
        public ViewResult Quotes()
        {
            List<Dictionary<string,object>> AllUsers = DbConnector.Query("SELECT * FROM Users");
            ViewBag.users = AllUsers;
            return View();
        }
        [HttpPost("make-quote")]
        public IActionResult Make_Quote(User user)
        {
            if(ModelState.IsValid)
            {
                DbConnector.Execute($"INSERT INTO Users (name, quote, created_at, updated_at) VALUES ('{user.name}', '{user.quote}', NOW(), NOW())");
                return RedirectToAction("Quotes");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
