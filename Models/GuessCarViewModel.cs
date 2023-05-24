using car_guess.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace car_guess.Models
{
    public class GuessCarViewModel
    {
        public int SelectedCarId { get; set; }
        public List<SelectListItem> CarList { get; set; }
        public Car SelectedCar { get; set; }
        public int Guess { get; set; }
    }
}