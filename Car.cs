public class Car
{
    public string Model { get; set; }
    public string Color { get; set; }
    public int Price { get; set; }
    public IPricingStrategy PricingStrategy { get; set; }

    public Car(string model, string color, int price, IPricingStrategy pricingStrategy)
    {
        Model = model;
        Color = color;
        Price = price;
        PricingStrategy = pricingStrategy;
    }

    public int CalculatePrice()
    {
        return PricingStrategy.CalculatePrice(Price);
    }
}