using System;

namespace netclectic.blockfrost.api
{
    public class RequestSent: EventArgs
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public DateTime TimeSent { get; } = DateTime.UtcNow;
        public string Message { get; }

        public RequestSent(string message)
        {
            Message = message;
        }
    }
}