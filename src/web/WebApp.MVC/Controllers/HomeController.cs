using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.MVC.Models;
using WebApp.MVC.Services;

namespace WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEncontrarDivisoresService _encontrarDivisoresService;

        public HomeController(IEncontrarDivisoresService encontrarDivisoresService)
        {
            _encontrarDivisoresService = encontrarDivisoresService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EncontrarDivisores(int numeroBase)
        {
            if (numeroBase <= 0) return View("Index");

            var divisores = await _encontrarDivisoresService.RetornarDivisoresNumero(numeroBase);
            divisores.NumeroBase = numeroBase;

            return View("Index", divisores);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
