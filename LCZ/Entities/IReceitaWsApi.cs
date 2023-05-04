using LCZ.Entities;
using Refit;

public interface IReceitaWSApi
{
    [Get("/{cnpj}")]
    Task<CnpjResponse> GetCnpjAsync(string cnpj);
}
