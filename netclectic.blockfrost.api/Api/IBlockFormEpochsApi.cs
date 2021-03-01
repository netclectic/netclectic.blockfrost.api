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
    }
}
