public class RegularPricingStrategy : IPricingStrategy
{
    public int CalculatePrice(int basePrice)
    {
        return basePrice;
    }
}