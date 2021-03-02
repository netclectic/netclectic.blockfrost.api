using RestEase;
using System.Threading.Tasks;

namespace netclectic.blockfrost.api
{
    public interface IBlockFormEpochsApi : IBlockFrostApiBase
    {
        /// <summary>
        /// Get the latest epoch
        /// </summary>
        /// <returns>Returns the information about the latest, therefore current, epoch</returns>
        [Get("/epochs/latest")]
        Task<EpochContent> GetLatestEpoch();

        /// <summary>
        /// Get a specific epoch
        /// </summary>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Returns the content of the requested epoch</returns>
        [Get("/epochs/{number}")]
        Task<EpochContent> GetEpoch([Path("number")] string number);

        /// <summary>
        /// Get a listing of next epochs
        /// </summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The numbers of epochs following the epoch specified. Max: 100</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Return the list of epochs following a specific epoch</returns>
        [Get("/epochs/{number}/next")]
        Task<EpochContent[]> GetNextEpoch([Path("number")] string number,
            [Query("count")] int count = 100,
            [Query("page")] int page = 1
            );

        /// <summary>
        /// Get a listing of previous epochs
        /// </summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The numbers of epochs preceding the epoch specified. Max: 100</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Returns the list of epochs preceding a specific epoch</returns>
        [Get("/epochs/{number}/previous")]
        Task<EpochContent[]> GetPrevEpoch([Path("number")] string number,
            [Query("count")] int count = 100,
            [Query("page")] int page = 1
            );

        /// <summary>
        /// Get epoch stake distribution
        /// </summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The numbers of stake addresses for a specific epoch. Max: 100</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Returns the active stake distribution for the epoch specified</returns>
        [Get("/epochs/{number}/stakes")]
        Task<EpochStakeContent[]> GetEpochStakes([Path("number")] string number,
            [Query("count")] int count = 100,
            [Query("page")] int page = 1
            );

        /// <summary>
        /// Get epoch stake distribution
        /// </summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="poolId">Stake pool ID to filter</param>
        /// <param name="count">The numbers of stake addresses for a specific epoch. Max: 100</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Returns the active stake distribution for the epoch specified</returns>
        [Get("/epochs/{number}/stakes/{pool_id}")]
        Task<EpochStakePoolContent[]> GetEpochStakesByPool([Path("number")] string number, [Path("pool_id")] string poolId,
            [Query("count")] int count = 100,
            [Query("page")] int page = 1
            );

        /// <summary>
        /// Get epoch block distribution
        /// </summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="count">The numbers of stake addresses for a specific epoch. Max: 100</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain, not the page listing itself. By default, we return oldest first, newest last</param>
        /// <returns>Returns the blocks minted for the epoch specified</returns>
        [Get("/epochs/{number}/blocks")]
        Task<string[]> GetEpochBlocks([Path("number")] string number,
            [Query("count")] int count = 100,
            [Query("page")] int page = 1,
            [Query("order")] QueryOrder? order = QueryOrder.asc
            );

        /// <summary>
        /// Get epoch block distribution
        /// </summary>
        /// <param name="number">Number of the epoch</param>
        /// <param name="poolId">Stake pool ID to filter</param>
        /// <param name="count">The numbers of stake addresses for a specific epoch. Max: 100</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <param name="order">The ordering of items from the point of view of the blockchain, not the page listing itself. By default, we return oldest first, newest last</param>
        /// <returns>Returns the blocks minted for the epoch specified</returns>
        [Get("/epochs/{number}/blocks/{pool_id}")]
        Task<string[]> GetEpochBlocksByPool([Path("number")] string number, [Path("pool_id")] string poolId,
            [Query("count")] int count = 100,
            [Query("page")] int page = 1,
            [Query("order")] QueryOrder? order = QueryOrder.asc
            );

        /// <summary>
        /// Get epoch protocol parameters
        /// </summary>
        /// <param name="number">Number of the epoch</param>
        /// <returns>Returns the protocol parameters for the epoch specified</returns>
        [Get("/epochs/{number}/parameters")]
        Task<EpochParamContent> GetEpochParameters([Path("number")] string number);
    }
}
