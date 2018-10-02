using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestChat.Filters;
using TestChat.Models;
using TestChat.Models.ViewModels;

namespace TestChat.Controllers
{
    [LogFilter]
    public class HomeController : Controller
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();

        public string Test(string test)
        {
            return  JsonConvert.SerializeObject(new ChatViewModel() { Message = "testMessage" });
        }

        public ActionResult Index()
        {
            return RedirectToAction("Chat");
        }

        public ActionResult JavascriptEvents()
        {
            return View();
        }

        public ActionResult Jquery()
        {
            return View();
        }

        public ActionResult TestForm()
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
                User = item.User != null ? item.User.Email : "Anonim"
            }).ToArray();
            return View(chatViewModel);
        }

        public ActionResult Messages(ChatViewModel chatView)
        {
            if (!string.IsNullOrEmpty(chatView.Message))
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
            }

            ChatViewModel chatViewModel = new ChatViewModel();
            chatViewModel.Messages = applicationDbContext.ChatMessages.Select(item => new MessageViewModel()
            {
                Message = item.Text,
                Time = item.Time,
                User = item.User != null ? item.User.Email : "Anonim"
            }).ToArray();
            return PartialView(chatViewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}