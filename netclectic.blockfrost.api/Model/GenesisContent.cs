namespace netclectic.blockfrost.api
{
    public record GenesisContent
    {
        /// <summary>
        /// The proportion of slots in which blocks should be issued
        /// </summary>
        public float ActiveSlotsCoefficient { get; init; }

        /// <summary>
        /// Determines the quorum needed for votes on the protocol parameter updates
        /// </summary>
        public int UpdateQuorum { get; init; }

        /// <summary>
        /// The total number of lovelace in the system
        /// </summary>
        public string MaxLovelaceSupply { get; init; }

        /// <summary>
        /// Network identifier
        /// </summary>
        public int NetworkMagic { get; init; }

        /// <summary>
        /// Number of slots in an epoch
        /// </summary>
        public int EpochLength { get; init; }

        /// <summary>
        /// Time of slot 0 in UNIX time
        /// </summary>
        public int SystemStart { get; init; }

        /// <summary>
        /// Number of slots in an KES period
        /// </summary>
        public int SlotsPerKesPeriod { get; init; }

        /// <summary>
        /// Duration of one slot in seconds
        /// </summary>
        public int SlotLength { get; init; }

        /// <summary>
        /// The maximum number of time a KES key can be evolved before a pool operator must create a new operational certificate
        /// </summary>
        public int MaxKesEvolutions { get; init; }

        /// <summary>
        /// Security parameter k
        /// </summary>
        public int SecurityParam { get; init; }
    }
}