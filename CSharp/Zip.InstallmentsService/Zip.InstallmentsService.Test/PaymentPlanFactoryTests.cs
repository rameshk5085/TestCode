using Shouldly;
using System.Linq;
using Xunit;

namespace Zip.InstallmentsService.Test
{
    public class PaymentPlanFactoryTests
    {
        [Fact]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnValidPaymentPlan()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory();
            
            // Act
            var paymentPlan = paymentPlanFactory.CreatePaymentPlan(123.45M);
            
            // Assert
            paymentPlan.ShouldNotBeNull();
            Assert.Equal(123.45M, paymentPlan.PurchaseAmount);
            Assert.Equal(4, paymentPlan.Installments.Length);
            Assert.Equal(123.45M, paymentPlan.Installments.Sum(a => a.Amount));


        }
    }
}
