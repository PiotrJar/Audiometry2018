using Audiometry2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace Audiometry2018.Controllers
{
    public class AccountController : Controller
    {


        public ActionResult Index()
        {

            return View();

        }
       
        public ActionResult Register()
        {

            return View();
        }


        //register
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {

            if (ModelState.IsValid)
            { using (OurDbContext db = new OurDbContext())
                {

                    db.userAccount.Add(account);
                    db.SaveChanges();


                }
                ModelState.Clear();
                ViewBag.Message = account.UserName + "Successfully registered";
                    
                        
            }
            return View();
        }

        //login
        public ActionResult Login()
        {

            return View();

        }


        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.userAccount.Single(u => u.Email == user.Email && u.Password == user.Password);
                if(usr != null)
                {
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("Main", "Home");

                }
                else
                {
                    ModelState.AddModelError("","UserName or Password is wrong");
                }
            }

            return View();
        }

        public ActionResult Main()
        {


            if(Session["UserName"] != null)
            {

                return View();
            }
            else
            {

                return RedirectToAction("Login");

            }
        }


        //send message

        public ActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("milosniktdk@gmail.com", "Piotr Jarząbek");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "Motocross16";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
    }
}