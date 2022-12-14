namespace PaymentProcessor.Domain.Utils;

public static class Extensions
{
    public static bool IsValid(this string source) => source is not null && !string.IsNullOrEmpty(source.Trim());
}