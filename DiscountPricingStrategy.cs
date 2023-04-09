public class DiscountPricingStrategy : IPricingStrategy
{
    private readonly double _discountPercentage;

    public DiscountPricingStrategy(double discountPercentage)
    {
        _discountPercentage = discountPercentage;
    }

    public int CalculatePrice(int basePrice)
    {
        return (int)(basePrice * (1 - _discountPercentage));
    }
}