using System;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// This class is responsible for building the PaymentPlan according to the Zip product definition.
    /// </summary>
    public class PaymentPlanFactory
    {
        /// <summary>
        /// Builds the PaymentPlan instance.
        /// </summary>
        /// <param name="purchaseAmount">The total amount for the purchase that the customer is making.</param>
        /// <returns>The PaymentPlan created with all properties set.</returns>
        public PaymentPlan CreatePaymentPlan(decimal purchaseAmount)
        {
            // TODO        

            int _installments = 4;
            int frequency = 14;

            DateTime CurrentInstallmentDate = DateTime.Now;
            var NewPaymentPlan = new PaymentPlan()
            {
                Id = Guid.NewGuid(),
                PurchaseAmount = purchaseAmount,
                Installments = new Installment[_installments]
            };

            decimal eachInstallmentAmount = Math.Round(purchaseAmount / _installments,2);
            decimal differenceAmount = purchaseAmount - (eachInstallmentAmount*4);

            for (int i = 0; i < _installments; i++)
            {
                NewPaymentPlan.Installments[i] = new Installment()
                {
                    Id = Guid.NewGuid(),
                    Amount = eachInstallmentAmount,
                    DueDate = CurrentInstallmentDate.AddDays(i* frequency)
                };
                if(i == _installments-1)
                {
                    NewPaymentPlan.Installments[i].Amount = NewPaymentPlan.Installments[i].Amount + differenceAmount;
                }
            }

            return NewPaymentPlan;
        }
    }
}
