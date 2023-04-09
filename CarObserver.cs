public class CarObserver : ICarObserver
{
    public void Update(Car car)
    {
        Console.WriteLine($"Car {car.Model} with price {car.Price} has been sold!");
    }
}