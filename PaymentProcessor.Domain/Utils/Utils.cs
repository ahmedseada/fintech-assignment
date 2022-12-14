using System.Security.Cryptography;
using System.Text;

namespace PaymentProcessor.Domain.Utils;

public static class Utils
{
    
    private const string PrivateHashKey = "51ca148f-2631-41c0-ba2f-4a748586a7f0";


    public static string GetHashKey() => PrivateHashKey;
    public static string ComputeSignature(string key)
    {
        using SHA256 sha256Hash = SHA256.Create();
        var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(key));
        StringBuilder builder = new();
        foreach (var t in bytes)
            builder.Append(t.ToString("x2"));

        return builder.ToString();
    }
}