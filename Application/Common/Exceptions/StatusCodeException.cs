using System.Net;

namespace Application.Common.Exceptions;

public class StatusCodeException : Exception
{
    public StatusCodeException(HttpStatusCode code, string message) : base(message)
    {
        StatusCode = code;
    }
    public HttpStatusCode StatusCode { get; }
}