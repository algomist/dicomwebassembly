
namespace IntegrationClient
{
    public interface IServiceClient
    {
        Task<string> GetWeathersAsync();
    }
}