using System;
using System.Collections.Generic;
using System.Text;
using Buscar_CEP.Servicos.Modelos;
using System.Net;
using Newtonsoft.Json;

namespace Buscar_CEP.Servicos
{
    class EnderecoViaCEP
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoCep = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();

            string conteudo = wc.DownloadString(NovoEnderecoCep);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if(end.cep == null)
            {
                return null;
            }
            else
            {
                return end;
            }
        }
    }
}
