namespace PaymentProcessor.Domain.Requests;

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Signature { get; set; }
}