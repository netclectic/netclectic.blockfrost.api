
namespace netclectic.blockfrost.api
{
    public record BlockContent
    {
        /// <summary>
        /// Block creation time in UNIX time
        /// </summary>
        public int Time { get; init; }

        /// <summary>
        /// Block number
        /// </summary>
        public int Height { get; init; }

        /// <summary>
        /// Hash of the block
        /// </summary>
        public string Hash{ get; init; }

        /// <summary>
        /// Slot number
        /// </summary>
        public int Slot { get; init; }

        /// <summary>
        /// Epoch number
        /// </summary>
        public int Epoch { get; init; }

        /// <summary>
        /// Slot within the epoch
        /// </summary>
        public int EpochSlot { get; init; }

        /// <summary>
        /// Bech32 ID of the slot leader or specific block description in case there is no slot leader
        /// </summary>
        public string SlotLeader { get; init; }

        /// <summary>
        /// Block size in Bytes
        /// </summary>
        public int Size { get; init; }

        /// <summary>
        /// Number of transactions in the block
        /// </summary>
        public int TxCount { get; init; }

        /// <summary>
        /// Total output within the block in Lovelaces
        /// </summary>
        public string Output { get; init; }

        /// <summary>
        /// Total fees within the block in Lovelaces
        /// </summary>
        public string Fees { get; init; }

        /// <summary>
        /// VRF key of the block
        /// </summary>
        public string BlockVRF { get; init; }

        /// <summary>
        /// Hash of the previous block
        /// </summary>
        public string PreviousBlock { get; init; }

        /// <summary>
        /// Hash of the next block
        /// </summary>
        public string NextBlock { get; init; }

        /// <summary>
        /// Number of block confirmations
        /// </summary>
        public int Confirmations { get; init; }
    }
}