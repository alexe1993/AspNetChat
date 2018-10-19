using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using TestChat.Filters;
using TestChat.Hubs;
using TestChat.Models;
using TestChat.Models.ViewModels;

namespace TestChat.Controllers
{
    [IEFilter]
    [LogFilter]
    public class HomeController : Controller
    {
        private ApplicationDbContext applicationDbContext = new ApplicationDbContext();

        public string Test(string test)
        {
            return JsonConvert.SerializeObject(new ChatViewModel() { Message = "testMessage" });
        }

        public ActionResult Index()
        {
            object v = RouteData.Values["id"];
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
            ChatViewModel chatViewModel = new ChatViewModel
            {
            };
            return View(chatViewModel);
        }

        public ActionResult GetPreviousMessages(int? id)
        {
            ChatMessage message = applicationDbContext.ChatMessages.Find(id);
            if (message == null) return PartialView("Messages", null); ;
            var lessTimeItems = applicationDbContext.
                ChatMessages.
                Where(item => item.Time <= message.Time && item.Time != message.Time);
            IQueryable <ChatMessage> messages =
               lessTimeItems.
                OrderBy(item => item.Time).
                Skip(Math.Max(lessTimeItems.Count()- 10,0));
            var messagesVievs = messages.Select(item => new MessageViewModel()
            {
                Id = item.Id,
                Message = item.Text,
                Time = item.Time,
                User = item.User!=null? item.User.Email : "Anonim"
            }).ToArray();
            return
                PartialView("Messages", messagesVievs);
        }

        private static int i = 0;

        [OutputCache(Duration = 30, Location = OutputCacheLocation.Client)]
        public string ChccheTest()
        {
            return (++i).ToString();
        }

        public string GetLastMessageCount()
        {
            return
                applicationDbContext.
                ChatMessages.Count().ToString();
        }

        public void SendMessage(MessageViewModel messageViewModel)
        {
            if (messageViewModel == null)
            {
                return;
            }

            Microsoft.AspNet.SignalR.IHubContext context =
                Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<ChutHub>();
            ApplicationUser user = GetCurrentUser();
            messageViewModel.Time = DateTime.Now;
            messageViewModel.User = user?.Email;
            bool sended = false;
            if (messageViewModel.MessageStatus == MessageStatus.New)
            {
                ChatMessage chatMessage = new ChatMessage()
                {
                    Text = messageViewModel.Message,
                    Time = DateTime.Now,
                    User = user
                };
                applicationDbContext.ChatMessages.Add(chatMessage);
                applicationDbContext.SaveChanges();
                sended = true;
            }
            if (messageViewModel?.User == user?.Email)
            {
                if (messageViewModel.MessageStatus == MessageStatus.Edited)
                {
                    ChatMessage message = applicationDbContext.ChatMessages.Find(messageViewModel.Id);
                    if (message != null)
                    {
                        message.Text = messageViewModel.Message;
                    }
                    applicationDbContext.Entry(message).State = EntityState.Modified;
                    applicationDbContext.SaveChanges();
                    sended = true;
                }
                else if (messageViewModel.MessageStatus == MessageStatus.Deleted)
                {
                    ChatMessage chatMessage = new ChatMessage()
                    {
                        Id = messageViewModel.Id,
                        Text = messageViewModel.Message,
                        Time = DateTime.Now,
                        User = user
                    };
                    applicationDbContext.Entry(chatMessage).State = EntityState.Deleted;
                    applicationDbContext.SaveChanges();
                    sended = true;
                }
            }
            if (sended)
            {
                context.Clients.All.addMessage(messageViewModel);
            }
        }

        public ActionResult Messages(int MessagesCount=10)
        {
            string userEmail = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            var Messages = applicationDbContext.ChatMessages.Select(item => new MessageViewModel()
            {
                Message = item.Text,
                Time = item.Time,
                User = item.User != null ? item.User.Email : "Anonim",
                Id = item.Id
            }).
            OrderBy(item => item.Time).
            Skip(Math.Max(0, applicationDbContext.ChatMessages.Count() - MessagesCount)).
            ToArray();
            return PartialView(Messages);
        }

        private ApplicationUser GetCurrentUser()
        {
            string userEmail = HttpContext.GetOwinContext().Authentication.User.Identity.Name;
            ApplicationUser user = applicationDbContext.Users.FirstOrDefault(item => item.Email == userEmail);
            return user;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}