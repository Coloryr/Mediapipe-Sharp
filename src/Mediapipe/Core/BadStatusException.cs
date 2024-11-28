using Mediapipe.Framework.Port;

namespace Mediapipe.Core;

public class BadStatusException : Exception
{
    public StatusCode StatusCode { get; private set; }

    public BadStatusException(string message) : base(message) { }

    public BadStatusException(StatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}
