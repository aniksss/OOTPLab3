public class CarShop
{
    private readonly List<Car> _cars;
    private readonly ICarObserver _observer;

    public CarShop(ICarObserver observer)
    {
        _cars = new List<Car>();
        _observer = observer;
    }

    public void AddCar(Car car)
    {
        _cars.Add(car);
    }

    public void SellCar(int index)
    {
        var car = _cars[index];
        var sellCarCommand = new SellCarCommand(car, _observer);
        sellCarCommand.Execute();
        _cars.RemoveAt(index);
    }
}