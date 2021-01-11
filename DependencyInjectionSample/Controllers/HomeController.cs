using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample.Models;
using DependencyInjectionSample.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyInjectionSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOperationSingleton _singletonOperation;
        private readonly IOperationSingletonInstance _singletonInstanceOperation;

        private readonly IOperationScoped _scopedOperation;

        private readonly IOperationTransient _transientOperation;
        
        private readonly OperationService _operationService;

        public HomeController(
            IOperationSingleton singletonOperation, 
            IOperationSingletonInstance singletonInstanceOperation, 
            IOperationScoped scopedOperation,
            IOperationTransient transientOperation, 
            OperationService operationService)
        {
            _singletonOperation = singletonOperation;
            _singletonInstanceOperation = singletonInstanceOperation;

            _scopedOperation = scopedOperation;

            _transientOperation = transientOperation;

            _operationService = operationService;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = _singletonOperation.OperationId;
            ViewBag.SingletonInstance = _singletonInstanceOperation.OperationId;

            ViewBag.Scoped = _scopedOperation.OperationId;

            ViewBag.Transient = _transientOperation.OperationId;

            ViewBag.Service = _operationService;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
