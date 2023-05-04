using Newtonsoft.Json;

namespace LCZ.Entities
{
    public class CepResponse
    {

        //[JsonProperty("cep")]
        //public string Cep { get; set; }
        //[JsonProperty("logradouro")]
        //public string Endereco { get; set; }
        //[JsonProperty("complemento")]
        //public string Complemento { get; set; }
        //[JsonProperty("localidade")]
        //public string Cidade { get; set; }
        //[JsonProperty("uf")]
        //public string Uf { get; set; }

        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string Ddd { get; set; }
        public string Siafi { get; set; }
    }
}
