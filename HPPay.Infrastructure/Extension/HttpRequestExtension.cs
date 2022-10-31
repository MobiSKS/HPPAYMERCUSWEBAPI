using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace HPPay.Infrastructure.Extension
{
    public static class HttpRequestExtension
    {
        public static string GetHeader(this HttpRequest request, string key)
        {
            request.Headers.TryGetValue(key, out StringValues value);
            return value.ToString ();

        }
    }
}
