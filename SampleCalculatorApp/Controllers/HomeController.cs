using Microsoft.AspNetCore.Mvc;
using SampleCalculatorApp.Models;
using System.Diagnostics;

namespace SampleCalculatorApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Operation model)
        {
            if (model.OperationType == OperationType.Addition)
                model.Result = model.NumberA + model.NumberB;
            if (model.OperationType == OperationType.Multiplication)
                model.Result = model.NumberA * model.NumberB;
            if (model.OperationType == OperationType.Division)
                model.Result = model.NumberA / model.NumberB;
            if (model.OperationType == OperationType.Subtraction)
                model.Result = model.NumberA - model.NumberB;

            return View(model);
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
