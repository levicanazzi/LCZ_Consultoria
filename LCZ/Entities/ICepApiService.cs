using LCZ.Entities;
using Refit;

namespace LCZ.Domain.Interfaces
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAddressAsync(string cep);
    }
}
