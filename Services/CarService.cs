using car_guess.Entities;

namespace car_guess.Services
{
    public class CarService : ICarService
    {
        // Static to In order to simulate some kind of "Database" , persisting the same value throghout the app lifetime
        private static List<Car> cars = new(){
            new Car { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
            new Car { Id = 2, Make = "Tesla", Model = "3",Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
            new Car { Id = 3, Make = "Porsche", Model = " 911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
            new Car { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 },
            new Car { Id = 5, Make = "BMW", Model = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 },
    };

        public void Create(string make, string model, int year, int doors, string color, decimal price)
        {
            var lastIdFromDatabase = cars.LastOrDefault().Id;
            var nextId = lastIdFromDatabase + 1;

            var newCar = Car.Create(nextId, make, model, year, doors, color, price);

            cars.Add(newCar);
        }

        public void Delete(int id)
        {
            var carToDelete = cars.FirstOrDefault(item => item.Id == id);

            if (carToDelete is null)
                throw new ArgumentNullException("Car does not exist");

            cars = cars.Where(item => item.Id != id).ToList();
        }

        public Car Get(int id)
        {
            var car = cars.FirstOrDefault(item => item.Id == id);

            if (car is null)
                throw new ArgumentNullException("Car does not exist");

            return car;
        }

        public List<Car> GetAll() => cars;


        public void Update(int id, string make, string model, int year, int doors, string color, decimal price)
        {
            var car = cars.FirstOrDefault(item => item.Id == id);

            if (car is null)
                throw new ArgumentNullException("Car does not exist");

            car.Update(make,model,year,doors,color,price);
        }
    }
}