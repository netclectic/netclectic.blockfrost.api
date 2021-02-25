using RestEase;
using System.Threading.Tasks;

namespace netclectic.blockfrost.api
{
    public interface IBlockFrostHealthApi : IBlockFrostApiBase
    {
        /// <summary>
        /// Return backend status as a boolean. Your application should handle situations when backend for the given chain is unavailable.
        /// </summary>
        /// <returns>Returns a boolean indicating the health of the backend</returns>
        [Get("/health")]
        Task<ApiHealth> GetApiHealth();

        /// <summary>
        /// This endpoint provides the current UNIX time. Your application might use this to verify if the client's clock is not out of sync.
        /// </summary>
        /// <returns>Returns the current UNIX time in milliseconds</returns>
        [Get("/health/clock")]
        Task<ApiClock> GetApiClock();
    }
}
