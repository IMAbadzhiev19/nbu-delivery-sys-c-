namespace OrdersDeliveryCalc;

internal static class ShippingPriceCalculator
{
    public const double EconomyRate = 4.00;
    public const double StandardRate = 6.00;
    public const double ExpressRate = 10.00;

    public static double CalculatePrice(double basePrice, double weight, double distance, bool toAddress, bool fragile)
    {
        double price = basePrice + (weight * 1.2 + distance * 0.05);

        if (toAddress)
            price += 5.00;
        if (fragile)
            price *= 1.30;

        return Math.Round(price, 2, MidpointRounding.AwayFromZero);
    }
}
