using RestEase;
using System.Threading.Tasks;

namespace netclectic.blockfrost.api
{
    public interface IBlockFrostRootApi : IBlockFrostApiBase
    {
        /// <summary>
        /// Root endpoint has no other function than to point end users to documentation
        /// </summary>
        /// <returns>Returns Information pointing to the documentation</returns>
        [Get("/")]
        Task<ApiInfo> GetApiInfo();
    }
}
