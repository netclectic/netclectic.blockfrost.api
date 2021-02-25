using RestEase;
using System.Threading.Tasks;

namespace netclectic.blockfrost.api
{
    public interface IBlockFromBlocksApi : IBlockFrostApiBase
    {
        /// <summary>
        /// Get the latest block available to the backends, also known as the tip of the blockchain.
        /// </summary>
        /// <returns>Returns the contents of the latest block</returns>
        [Get("/blocks/latest")]
        Task<BlockContent> GetLatestBlock();

        /// <summary>
        /// Get the content of a specific block
        /// </summary>
        /// <param name="hash">Hash of the requested block. 64-character case-sensitive hexadecimal string or block number</param>
        /// <returns>Returns the content of a requested block</returns>
        [Get("/blocks/{hash_or_number}")]
        Task<BlockContent> GetBlock([Path("hash_or_number")] string hash);

        /// <summary>
        /// Get listing of next blocks
        /// </summary>
        /// <param name="hash">Hash of the requested block. 64-character case-sensitive hexadecimal string or block number</param>
        /// <param name="count">The numbers of blocks following the block specified. Max: 100</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Returns the list of blocks following a specific block</returns>
        [Get("/blocks/{hash_or_number}/next")]
        Task<BlockContent[]> GetNextBlocks([Path("hash_or_number")] string hash,
            [Query("count")] int count = 100,
            [Query("page")] int page = 1
            );

        /// <summary>
        /// Get listing of previous blocks
        /// </summary>
        /// <param name="hash">Hash of the requested block. 64-character case-sensitive hexadecimal string or block number</param>
        /// <param name="count">The numbers of blocks following the block specified. Max: 100</param>
        /// <param name="page">The page number for listing the results.</param>
        /// <returns>Returns the list of blocks preceding a specific block</returns>
        [Get("/blocks/{hash_or_number}/previous")]
        Task<BlockContent[]> GetPrevBlocks([Path("hash_or_number")] string hash,
            [Query("count")] int count = 100,
            [Query("page")] int page = 1
            );
    }
}
