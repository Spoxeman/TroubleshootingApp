using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trouble_shootingApp.Models;
using System.Data.SqlClient;
using Trouble_shootingApp.DataServices;

namespace Trouble_shootingApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataServices.DataService _dataService;

    public HomeController(ILogger<HomeController> logger, DataService dataService)
    {
        _logger = logger;
        _dataService = dataService;
    }

    public IActionResult Index()
    {

        var vm = _dataService.GetJourneys();
        
        return View(vm);
    }

  
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

