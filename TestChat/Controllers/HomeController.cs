using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestChat.Models;
using TestChat.Models.ViewModels;

namespace TestChat.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Chat()
        {
            ChatViewModel chatViewModel = new ChatViewModel();
            chatViewModel.Messages = applicationDbContext.ChatMessages.Select(item => new MessageViewModel()
            {
                Message = item.Text,
                Time = item.Time,
                User = item.User!=null? item.User.Email:"Anonim"
            }).ToArray();
            return View(chatViewModel);
        }

        public ActionResult SendMessage(ChatViewModel chatView)
        {
            var userEmail = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            var user = applicationDbContext.Users.FirstOrDefault(item => item.Email == userEmail);
            ChatMessage chatMessage = new ChatMessage()
            {
                Text = chatView.Message,
                Time = DateTime.Now,
                User = user
            };
            applicationDbContext.ChatMessages.Add(chatMessage);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Chat");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}