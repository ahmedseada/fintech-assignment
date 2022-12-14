using Newtonsoft.Json;

namespace PaymentProcessor.Domain.Requests;

public class PaymentRequest
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    [JsonProperty("ProcessingCode")] public int ProcessingCode { get; set; }

    [JsonProperty("SystemTraceNr")] public int SystemTraceNr { get; set; }

    [JsonProperty("FunctionCode")] public int FunctionCode { get; set; }

    [JsonProperty("CardNo")] public string CardNo { get; set; }

    [JsonProperty("CardHolder")] public string CardHolder { get; set; }

    [JsonProperty("AmountTrxn")] public int AmountTrxn { get; set; }

    [JsonProperty("CurrencyCode")] public int CurrencyCode { get; set; }
    [JsonProperty("Signature")] public string Signature { get; set; }
    
}