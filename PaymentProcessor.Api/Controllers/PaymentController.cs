using Microsoft.AspNetCore.Mvc;
using PaymentProcessor.Domain.Models;
using PaymentProcessor.Domain.Requests;
using PaymentProcessor.Domain.Responses;
using PaymentProcessor.Services.Payment;

namespace PaymentProcessor.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    [Route("[action]")]
    public ProcessedPaymentResponse GetPayment([FromBody] PaymentRequest request)
    {
        var model = new PaymentModel()
        {
            Amount = request.AmountTrxn,
            Signature = request.Signature,
            CardNumber = request.CardNo,
            CardHolderName = request.CardHolder
        };
        var validPayment = _paymentService.IsValidPayment(model);

        if (!validPayment) return new();

        var result = _paymentService.ProcessPayment(model);
        return new ProcessedPaymentResponse()
        {
            Message = result.Message,
            ApprovalCode = result.ApprovalCode,
            DateTime = (int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
            ResponseCode = 0,
            Done = true
        };
    }
    
    
}