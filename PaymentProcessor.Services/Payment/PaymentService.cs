using PaymentProcessor.Domain.Models;
using PaymentProcessor.Domain.Utils;

namespace PaymentProcessor.Services.Payment;

public class PaymentService : IPaymentService
{

    public bool IsValidPayment(PaymentModel model)
    {
        var computeHash =
            Utils.ComputeSignature($"{model.CardHolderName}{model.CardNumber}{model.Amount}{Utils.GetHashKey()}");
        return computeHash == model.Signature;
    }

    public PaymentResult ProcessPayment(PaymentModel model)
    {
        var approval = Random.Shared.Next(111111, 999999);

        return new PaymentResult()
        {
            Message = "Successful Payment ",
            ApprovalCode = approval
        };
    }
 
}