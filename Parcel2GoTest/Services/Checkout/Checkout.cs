namespace Parcel2GoTest.Services.Checkout;

public class Checkout : ICheckout
{
    public int ServiceACount { get; private set; }
    public int ServiceBCount { get; private set; }
    public int ServiceCCount { get; private set; }
    public int ServiceDCount { get; private set; }
    public int ServiceFCount { get; private set; }

    public void Scan(string service)
    {
        switch (service)
        {
            case "A":
                AddServiceA();
                break;
            case "B":
                AddServiceB();
                break;
            case "C":
                AddServiceC();
                break;
            case "D":
                AddServiceD();
                break;
            case "F":
                AddServiceF();
                break;
            default:
                // log error
                Console.WriteLine("Error: Service Does Not Exist");
                break;
        }
    }

    public int GetTotalPrice()
    {
        int totalPrice = 0;

        if (this.ServiceACount > 0)
        {
            totalPrice += CalculateServicePromotionTotal(
                this.ServiceACount, 
                Constants.CheckoutConstants.ServiceAMultipleDiscountPolicy,
                Constants.CheckoutConstants.ServiceAOriginalPrice,
                Constants.CheckoutConstants.ServiceADiscountPrice);
        }

        if (this.ServiceBCount > 0)
        {
            totalPrice += CalculateServicePromotionTotal(
                this.ServiceBCount,
                Constants.CheckoutConstants.ServiceBMultipleDiscountPolicy,
                Constants.CheckoutConstants.ServiceBOriginalPrice,
                Constants.CheckoutConstants.ServiceBDiscountPrice);
        }

        if (this.ServiceCCount > 0)
        {
            totalPrice += CalculateServiceCTotalPrice();
        }

        if (this.ServiceDCount > 0)
        {
            totalPrice += CalculateServiceDTotalPrice();
        }

        if (this.ServiceFCount > 0)
        {
            totalPrice += CalculateServicePromotionTotal(
                this.ServiceFCount,
                Constants.CheckoutConstants.ServiceFMultipleDiscountPolicy,
                Constants.CheckoutConstants.ServiceFOriginalPrice,
                Constants.CheckoutConstants.ServiceFDiscountPrice);
        }

        return totalPrice;
    }

    private static int CalculateServicePromotionTotal(
        int serviceCount,
        int serviceMultipleDiscount,
        int serviceOriginalPrice,
        decimal serviceDiscountPrice)
    {
        var remainder = serviceCount % serviceMultipleDiscount;

        // apply discount when odd/even services in basket
        return (int)Math.Round(((serviceCount - remainder) * serviceDiscountPrice) + (serviceOriginalPrice * remainder));
    }

    private int CalculateServiceCTotalPrice()
    {
        return this.ServiceCCount * Constants.CheckoutConstants.ServiceCPrice;
    }

    private int CalculateServiceDTotalPrice()
    {
        return this.ServiceDCount * Constants.CheckoutConstants.ServiceDPrice;
    }

    private void AddServiceA()
    {
        this.ServiceACount++;
    }

    private void AddServiceB()
    {
        this.ServiceBCount++;
    }

    private void AddServiceC()
    {
        this.ServiceCCount++;
    }

    private void AddServiceD()
    {
        this.ServiceDCount++;
    }

    private void AddServiceF()
    {
        this.ServiceFCount++;
    }
}
