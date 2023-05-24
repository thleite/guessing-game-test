using car_guess.Entities;

namespace car_guess.Services
{
    public interface ICarService
    {
         List<Car> GetAll();

         Car Get(int id);

         void Create(string make, string model, int year, int doors, string color, decimal price);

         void Update(int id, string make, string model, int year, int doors, string color, decimal price);

         void Delete(int id);

    }
}