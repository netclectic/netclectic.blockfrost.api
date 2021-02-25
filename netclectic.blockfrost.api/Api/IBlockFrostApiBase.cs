using RestEase;

namespace netclectic.blockfrost.api
{
    public interface IBlockFrostApiBase
    {
        [Header("project_id")]
        string ApiKey { get; set; }
    }
}
