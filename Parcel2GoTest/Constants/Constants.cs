namespace Parcel2GoTest.Constants;

public static class CheckoutConstants
{
    // -- Test Notes --
    // Service A: £10 each or 3 for £25
    // Service B: £12 each or 2 for £20
    // Service C: £15 each
    // Service D: £25 each
    // Service F: £8 each or 2 for £15

    // Service A
    public const int ServiceAMultipleDiscountPolicy = 3;
    public const int ServiceAOriginalPrice = 10;
    public const decimal ServiceADiscountPrice = 8.33M;

    // Service B
    public const int ServiceBMultipleDiscountPolicy = 2;
    public const int ServiceBOriginalPrice = 12;
    public const int ServiceBDiscountPrice = 10;

    // Service C
    public const int ServiceCPrice = 15;

    // Service D
    public const int ServiceDPrice = 25;

    // Service F
    public const int ServiceFMultipleDiscountPolicy = 2;
    public const int ServiceFOriginalPrice = 8;
    public const decimal ServiceFDiscountPrice = 7.5M;
}
