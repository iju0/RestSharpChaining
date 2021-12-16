using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpChaining
{
    using RestSharp;
    using System.Web;

    public class ApiClient
    {
        private RestClient _restClient;
        private RestRequest _restRequest;
        private Encoding _encoding;

        public ApiClient(string url)
        {
            _restClient = new RestClient(url);
            _restRequest = new RestRequest();
            _encoding = Encoding.GetEncoding("UTF-8");
        }

        public ApiClient SetHeader(ICollection<ApiHeader> apiHeaders)
        {
            if (apiHeaders != null && apiHeaders.Count > 0)
            {
                _restRequest.Parameters
                    .Where(parameter => parameter.Type == ParameterType.HttpHeader)
                    .ToList()
                    .Clear();

                foreach (var header in apiHeaders)
                {
                    _restRequest.AddHeader(header.Name, header.Value);
                }
            }

            return this;
        }

        public ApiClient SetQueryString(ICollection<ApiParameter> apiParameters)
        {
            if (apiParameters != null && apiParameters.Count > 0)
            {
                _restRequest.Parameters
                    .Where(parameter => parameter.Type == ParameterType.QueryString)
                    .ToList()
                    .Clear();

                foreach (var parameter in apiParameters)
                {
                    _restRequest.AddQueryParameter(parameter.Name, parameter.Value);
                }
            }

            return this;
        }

        public ApiClient SetBody<TDomainModel>(TDomainModel domainModel)
        {
            if (domainModel != null)
            {
                _restRequest.Parameters
                    .Where(parameter => parameter.Type == ParameterType.RequestBody)
                    .ToList()
                    .Clear();

                _restRequest.AddParameter("applicaion/json", SimpleJson.SerializeObject(domainModel), ParameterType.RequestBody);
            }

            return this;
        }

        public ApiClient SetEncoding(string charset)
        {
            if (!string.IsNullOrEmpty(charset))
            {
                _encoding = Encoding.GetEncoding(charset);
            }
            return this;
        }

        public TDomainModel Get<TDomainModel>()
        {
            _restRequest.Method = Method.GET;
            return Execute<TDomainModel>();
        }

        public TDomainModel Post<TDomainModel>()
        {
            _restRequest.Method = Method.POST;
            return Execute<TDomainModel>();
        }

        public TDomainModel Patch<TDomainModel>()
        {
            _restRequest.Method = Method.PATCH;
            return Execute<TDomainModel>();
        }

        public TDomainModel Delete<TDomainModel>()
        {
            _restRequest.Method = Method.DELETE;
            return Execute<TDomainModel>();
        }

        private TDomainModel Execute<TDomainModel>()
        {
            return SimpleJson.DeserializeObject<TDomainModel>(Execute());
        }

        private string Execute()
        {
            var response = _restClient.Execute(_restRequest);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new HttpException(404, "Not Found Exception");
            }

            var result = _encoding.GetString(response.RawBytes);

            return result;
        }


    }
}
