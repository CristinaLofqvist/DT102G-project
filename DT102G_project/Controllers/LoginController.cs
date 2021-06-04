using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT102G_Moment_3_2.Data;
using DT102G_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DT102G_project.Controllers
{
    public class LoginController : Controller
    {
        private readonly WarehouseContext _context;

        public LoginController(WarehouseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        // POST: Login/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                List<User> users = await _context.Users.ToListAsync();
                foreach (User user in users)
                {
                    if (user.Password.Equals(login.Password) && user.Username.Equals(login.Username))
                    {
                        SetCookie("loggedin", login.Username, 100);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View("Index");
        }
        private void SetCookie(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);

            Response.Cookies.Append(key, value, option);
        }
        public IActionResult Logout()
        {
            SetCookie("loggedin", "", 100);
            return RedirectToAction("Index", "Home");
        }
    }
}