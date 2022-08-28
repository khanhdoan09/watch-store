using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string Email, string Password)
        {
            return View();
        }
        public ActionResult SubmitLogin(string Email, string Password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("GetSignIn?Email=" + Email + "&Password=" + Password);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "ManageBrand", new { area = "Admin" });
                }
            }
            ViewBag.Error = Email +"~" + Password;
            return View("Login");
        }

        public ActionResult Register()
        {           
            return View();
        }
        public ActionResult SubmitRegsiter(Customer customer)
        {
            if (ModelState.IsValid)
            {              
                if (CheckEmailExist(customer.Email))
                {
                    ViewBag.Error = "Email Is Existed";
                    return View("Register");
                }
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44380/api/");
                    var rs = client.PutAsJsonAsync<Customer>("PutRegister", customer);
                    rs.Wait();
                    var re = rs.Result;
                    if (re.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "ManageBrand", new { area = "Admin" });
                    }
                }
            }
            ViewBag.Error = "Register Fail";
            return View("Register");
        }

        private Boolean CheckEmailExist(string Email)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("GetCheckEmail?Email=" + Email);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}