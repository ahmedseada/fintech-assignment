using PaymentProcessor.Domain.Models;

namespace PaymentProcessor.Services.Payment;

public interface IPaymentService
{
    bool IsValidPayment(PaymentModel model);
    PaymentResult ProcessPayment(PaymentModel model);

}