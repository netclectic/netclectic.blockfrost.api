
namespace netclectic.blockfrost.api
{
    public record EpochContent
    {
        /// <summary>
        /// Epoch number
        /// </summary>
        public int Epoch { get; init; }

        /// <summary>
        /// Unix time of the start of the epoch
        /// </summary>
        public int StartTime { get; init; }

        /// <summary>
        /// Unix time of the end of the epoch
        /// </summary>
        public int EndTime { get; init; }

        /// <summary>
        /// Number of blocks within the epoch
        /// </summary>
        public int BlocksCount { get; init; }

        /// <summary>
        /// Number of transactions within the epoch
        /// </summary>
        public int TxsCount { get; init; }

        /// <summary>
        /// Sum of all the transactions within the epoch in Lovelaces
        /// </summary>
        public string TxsSum { get; init; }

        /// <summary>
        /// Sum of all the fees within the epoch in Lovelaces
        /// </summary>
        public string FeesSum { get; init; }
    }
}