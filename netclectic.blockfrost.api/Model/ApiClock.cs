using System;

namespace netclectic.blockfrost.api
{
    public record ApiClock(int ServerTime)
    {
        public DateTime ToUtcDateTime()
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(ServerTime).UtcDateTime;
        }
    }
}
