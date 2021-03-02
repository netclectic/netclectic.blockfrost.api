
namespace netclectic.blockfrost.api
{
    public record EpochStakeContent
    {
        /// <summary>
        /// Stake address
        /// </summary>
        public string StakeAddress { get; init; }

        /// <summary>
        /// Bech32 prefix of the pool delegated to
        /// </summary>
        public string PoolId { get; init; }

        /// <summary>
        /// Amount of delegated stake in Lovelaces
        /// </summary>
        public string Amount { get; init; }
    }
}