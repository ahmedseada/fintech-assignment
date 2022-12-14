using System.Security.Cryptography;

using PaymentProcessor.Domain.Models;
using PaymentProcessor.Domain.Utils;

namespace PaymentProcessor.Services.Auth;

public class AuthService : IAuthService

{
    private const string Username = "admin";
    private const string Password = "admin";


    public LoginResult Login(string userName, string password, string signature)
    {
        if (!userName.IsValid() || !Password.IsValid())
            return new LoginResult() {IsSuccess = false};

        if (userName != Username) return new LoginResult() {IsSuccess = false, ErrorMessage = "Username not found"};
        if (password != Password)
            return new LoginResult() {IsSuccess = false, ErrorMessage = "Invalid Password"};

        var computedSignature = Utils.ComputeSignature($"{userName}{Utils.GetHashKey()}{password}");

        if (computedSignature != signature)
            return new LoginResult() {IsSuccess = false, ErrorMessage = "Invalid Signature Or Something Went Wrong"};

        return new LoginResult() {IsSuccess = true, ErrorMessage = string.Empty};
    }

 
}