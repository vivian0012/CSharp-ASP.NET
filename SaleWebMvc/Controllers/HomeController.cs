using Microsoft.AspNetCore.Mvc;
using SaleWebMvc.Models;
using System.Diagnostics;

namespace SaleWebMvc.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {
            // Instanciando os valores e setando para o INDEX
            HomeModel home = new HomeModel();
            home.Nome = "Vivian";
            home.Email = "vivian2563@gmail.com";

            return View(home);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
