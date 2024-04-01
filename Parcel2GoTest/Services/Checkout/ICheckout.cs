namespace Parcel2GoTest.Services.Checkout;

public interface ICheckout
{
    public void Scan(string service);
    public int GetTotalPrice();
}
