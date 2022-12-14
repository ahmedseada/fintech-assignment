namespace PaymentProcessor.Domain.Models;

public class LoginResult
{
    public bool IsSuccess { get; set; }
    
    public string ErrorMessage { get; set; }
}