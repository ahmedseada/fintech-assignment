namespace PaymentProcessor.Domain.Models;

public class PaymentModel
{
    public string CardHolderName { get; set; }
    public int Amount { get; set; }
    public string CardNumber { get; set; }
    public string Signature { get; set; }
}