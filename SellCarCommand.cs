public class SellCarCommand : ICommand
{
    private readonly Car _car;
    private readonly ICarObserver _observer;

    public SellCarCommand(Car car, ICarObserver observer)
    {
        _car = car;
        _observer = observer;
    }

    public void Execute()
    {
        _observer.Update(_car);
    }
}