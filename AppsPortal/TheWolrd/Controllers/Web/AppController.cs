
using TheWolrd.Services;
using Microsoft.AspNet.Mvc;
using TheWolrd.ViewModels;
using TheWolrd.Models;
using System.Linq;

namespace TheWolrd.Controllers.Web
{

    public class AppController :Controller
    {

        private IMailService _mailService;
        private IWorldRepository _repository;

        public AppController(IMailService service,IWorldRepository repository)
        {
            _mailService = service;
            _repository = repository;
        }


        public IActionResult Index()
        {
            var trips = _repository.GetAllTrips();

            return View(trips);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            _mailService.SendMail("","",$"Contact Page from {model.Name} ({model.Email})",model.Message);
            return View();
        }
    }
}