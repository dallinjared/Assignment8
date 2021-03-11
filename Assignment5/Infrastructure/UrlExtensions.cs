using System;
using Microsoft.AspNetCore.Http;

namespace Assignment5.Infrastructure
{
    public static class UrlExtensions
    {
        //generates URL extensions that the browser will return after the cart has been updated
        public static string PathAndQuery(this HttpRequest request) =>
                    request.QueryString.HasValue
                        ? $"{request.Path}{request.QueryString}"
                        : request.Path.ToString();
    }
}
