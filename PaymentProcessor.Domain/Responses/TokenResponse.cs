using Newtonsoft.Json;

namespace PaymentProcessor.Domain.Responses;

public class TokenResponse
{
    [JsonProperty("signature")]
    public string Signature { get; set; }
}