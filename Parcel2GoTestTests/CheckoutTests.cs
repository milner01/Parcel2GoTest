using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcel2GoTest.Services.Checkout;

namespace Parcel2GoTestTests;

[TestClass]
public class CheckoutTests
{
    [TestMethod]
    public void GivenMultipurchaseDiscount_WhenICallGetTotalPrice_ThenMultiDiscountApplies()
    {
        /*
          Example 1: Multipurchase Discount Advantage
          Customer's Cart: 2 x Service B
          Standard Pricing: £12 each
          Special Offer for B: 2 for £20
          Total without discount: 2 x £12 = £24
          With multipurchase discount: £20
          Decision: The system applies the multipurchase discount, totaling £20, as it offers better savings.
        */

        // Given
        Checkout checkout = new();
        checkout.Scan("B");
        checkout.Scan("B");

        var expectedResult = 20;

        // When
        var result = checkout.GetTotalPrice();

        // Then
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void GivenNoMultipurchaseDiscount_WhenICallGetTotalPrice_ThenNoDiscountApplies()
    {
        /*
          Example 2: No Multipurchase Discount
          Customer's Cart: 1 x Service F and 1 x Service C
          Standard Pricing: Service F at £8 and Service C at £15
          No applicable multipurchase discount.
          Total without discount: £8 + £15 = £23
          Decision: The system calculates the total as £23 due to no available
          multipurchase discounts.
        */

        // Given
        Checkout checkout = new();
        checkout.Scan("F");
        checkout.Scan("C");

        var expectedResult = 23;

        // When
        var result = checkout.GetTotalPrice();

        // Then
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void GivenAMixOfDiscountAndNonDiscountServices_WhenICallGetTotalPrice_ThenDiscountsApply()
    {
        /* 
          Example 3: Mix of Discounts and No Discount
          Customer's Cart: 2 x Service F, 1 x Service B
          Standard Pricing: F @ £8 each, B @ £12 each
          Special Offer for F: 2 for £15
          Total without discount: 2 x £8 + 1 x 12 = £28
          With multipurchase discount: £27
          Decision: The system applies the multipurchase discount for the F products, no discount on B as only 1 bought reducing the total to £27.
        */

        // Given
        Checkout checkout = new();
        checkout.Scan("F");
        checkout.Scan("F");
        checkout.Scan("B");

        var expectedResult = 27;

        // When
        var result = checkout.GetTotalPrice();

        // Then
        Assert.AreEqual(expectedResult, result);
    }


    // Additional Out Of Scope Tests 
    [TestMethod]
    public void GivenOddNumberOfServiceBMultipurchaseDiscount_WhenICallGetTotalPrice_ThenMultiDiscountAppliesToOnlyTheMultipleServices()
    {
        // Given
        Checkout checkout = new();

        // 2 for £20 + £12
        checkout.Scan("B");
        checkout.Scan("B");
        checkout.Scan("B");

        var expectedResult = 32;

        // When
        var result = checkout.GetTotalPrice();

        // Then
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void GivenOddNumberOfServiceAMultipurchaseDiscount_WhenICallGetTotalPrice_ThenMultiDiscountAppliesToOnlyTheMultipleServices()
    {
        // Given
        Checkout checkout = new();

        // 3 for £25 + £10
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");

        var expectedResult = 35;

        // When
        var result = checkout.GetTotalPrice();

        // Then
        Assert.AreEqual(expectedResult, result);
    }
}