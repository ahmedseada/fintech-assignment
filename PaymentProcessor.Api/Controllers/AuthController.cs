using Microsoft.AspNetCore.Mvc;
using PaymentProcessor.Domain.Requests;
using PaymentProcessor.Domain.Responses;
using PaymentProcessor.Services.Auth;

namespace PaymentProcessor.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [Route("[action]")]
    public AuthResponse Login([FromBody] LoginRequest loginRequest)
    {
        var result = _authService.Login(loginRequest.Username, loginRequest.Password, loginRequest.Signature);
        return new AuthResponse() {Done = result.IsSuccess, Errors = result.ErrorMessage};
    }
}