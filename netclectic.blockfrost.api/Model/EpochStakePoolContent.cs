
namespace netclectic.blockfrost.api
{
    public record EpochStakePoolContent
    {
        /// <summary>
        /// Stake address
        /// </summary>
        public string StakeAddress { get; init; }

        /// <summary>
        /// Amount of delegated stake in Lovelaces
        /// </summary>
        public string Amount { get; init; }
    }
}