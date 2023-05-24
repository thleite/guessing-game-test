using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using car_guess.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using car_guess.Services;
using car_guess.Entities;

namespace car_guess.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ICarService _carService;

    public HomeController(ILogger<HomeController> logger, ICarService carService)
    {
        _logger = logger;
        _carService = carService;
    }

    public IActionResult Index()
    {
        var model = new GuessCarViewModel
        {
            CarList = GetCarList()
        };

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private List<SelectListItem> GetCarList()
    {

        var cars = _carService.GetAll();

        return cars.Select(item => new SelectListItem { Value = item.Id.ToString(), Text = $"{item.Make} {item.Model}" }).ToList();

    }


    [HttpPost]
    public ActionResult CheckGuess(GuessCarViewModel model)
    {
        var selectedCar = _carService.Get(model.SelectedCarId);

        var carPrice = selectedCar.Price;

        var difference = Math.Abs(model.Guess - carPrice);
        
        var success = difference <= 5000;

        var result = new
        {
            Success = success,
            Message = success
                ? "Great job! Your guess is within $5,000 of the actual price."
                : "Sorry, your guess is more than $5,000 away from the actual price."
        };

        ViewBag.Result = result;

        model.CarList = GetCarList();
        model.SelectedCarId = model.SelectedCarId;

        return View("Index",model);
    }

    public ActionResult SelectCar(int id)
    {
        if(id == 0)
            return PartialView("_CarInfo",null);

        var car = _carService.Get(id);

        var maskedCar = new MaskedCarViewModel{
            Color = car.Color,
            Doors = car.Doors,
            Make = car.Make,
            Model = car.Model,
            Year = car.Year
        };


        return PartialView("_CarInfo",maskedCar);
    }

}
