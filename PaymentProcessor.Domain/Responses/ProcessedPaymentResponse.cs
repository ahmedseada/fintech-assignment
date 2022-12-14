using Newtonsoft.Json;

namespace PaymentProcessor.Domain.Responses;

public class ProcessedPaymentResponse
{
    [JsonProperty("ResponseCode")] public int ResponseCode { get; set; }

    [JsonProperty("Message")] public string Message { get; set; }

    [JsonProperty("ApprovalCode")] public int ApprovalCode { get; set; }

    [JsonProperty("DateTime")] public long DateTime { get; set; }
    [JsonProperty("done")] public bool Done { get; set; } 
}