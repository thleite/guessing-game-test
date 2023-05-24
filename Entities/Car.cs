namespace car_guess.Entities
{
    public class Car
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int Doors { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public static Car Create(int id, string make, string model, int year, int doors, string color, decimal price)
        {
            return new Car()
            {
                Id = id,
                Make = make,
                Model = model,
                Year = year,
                Doors = doors,
                Color = color,
                Price = price
            };
        }

        public void Update(string make, string model, int year, int doors, string color, decimal price)
        {
            Make = make;
            Model = model;
            Year = year;
            Doors = doors;
            Color = color;
            Price = price;
        }

    }
}