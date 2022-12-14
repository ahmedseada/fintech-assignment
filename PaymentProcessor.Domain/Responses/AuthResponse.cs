namespace PaymentProcessor.Domain.Responses;

public class AuthResponse
{
    public bool Done { get; set; }
    public string Errors { get; set; } = string.Empty;
}