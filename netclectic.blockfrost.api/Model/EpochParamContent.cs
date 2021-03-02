
namespace netclectic.blockfrost.api
{
    public record EpochParamContent
    {
        /// <summary>
        /// The linear factor for the minimum fee calculation for given epoch
        /// </summary>
        public int MinFeeA { get; init; }

        /// <summary>
        /// The constant factor for the minimum fee calculation
        /// </summary>
        public int MinFeeB { get; init; }

        /// <summary>
        /// Maximum block body size in Bytes
        /// </summary>
        public int MaxBlockSize { get; init; }

        /// <summary>
        /// Maximum transaction size
        /// </summary>
        public int MaxTxSize { get; init; }

        /// <summary>
        /// Maximum block header size
        /// </summary>
        public int MaxBlockHeaderSize { get; init; }

        /// <summary>
        /// The amount of a key registration deposit in Lovelaces
        /// </summary>
        public string KeyDeposit { get; init; }

        /// <summary>
        /// The amount of a pool registration deposit in Lovelaces
        /// </summary>
        public string PoolDeposit { get; init; }

        /// <summary>
        /// Epoch bound on pool retirement
        /// </summary>
        public int EMax { get; init; }

        /// <summary>
        /// Desired number of pools
        /// </summary>
        public int NOpt { get; init; }

        /// <summary>
        /// Pool's pledge influence
        /// </summary>
        public float A0 { get; init; }

        /// <summary>
        /// Monetary expansion
        /// </summary>
        public float Rho { get; init; }

        /// <summary>
        /// Treasury expansion
        /// </summary>
        public float Tau { get; init; }

        /// <summary>
        /// Percentage of blocks produced by federated nodes
        /// </summary>
        public float DecentralisationParam { get; init; }

        /// <summary>
        /// Seed for extra entropy
        /// </summary>
        public object ExtraEntropy { get; init; }

        /// <summary>
        /// Accepted protocol major version
        /// </summary>
        public int ProtocolMajorVer { get; init; }

        /// <summary>
        /// Accepted protocol minor version
        /// </summary>
        public int ProtocolMinorVer { get; init; }

        /// <summary>
        /// Minimum UTXO value
        /// </summary>
        public string MinUtxo { get; init; }

        /// <summary>
        /// Minimum stake cost forced on the pool
        /// </summary>
        public string MinPoolCost { get; init; }

        /// <summary>
        /// Epoch's number only used once
        /// </summary>
        public string Nonce { get; init; }
    }
}