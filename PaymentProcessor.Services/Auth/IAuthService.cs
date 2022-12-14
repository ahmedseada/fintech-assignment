
using PaymentProcessor.Domain.Models;

namespace PaymentProcessor.Services.Auth;

public interface IAuthService
{
     LoginResult Login(string userName, string password, string signature);
     
}