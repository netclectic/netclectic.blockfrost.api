using System;

namespace netclectic.blockfrost.api
{
    public class ResponseReceived: EventArgs
    {
        public string Id { get; }
        public DateTime TimeResponseReceived { get; } = DateTime.UtcNow;

        public ResponseReceived(string id)
        {
            Id = id;
        }
    }
}