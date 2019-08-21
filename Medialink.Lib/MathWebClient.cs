using Medialink.Lib.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;

namespace Medialink.Lib
{
    public class MathWebClient
    {
        private readonly IRestClient _restClient;
        private readonly ILogger<MathWebClient> _logger;
        private readonly IImportantObjectRepository _importantObjectRepository;

        public MathWebClient(IImportantObjectRepository importantObjectRepository, ILogger<MathWebClient> logger)
        {
            _restClient = new RestClient("https://localhost:44374/api/math/");
            _importantObjectRepository = importantObjectRepository;
            _logger = logger;
        }

        public MathWebClient(IRestClient restClient, IImportantObjectRepository importantObjectRepository, ILogger<MathWebClient> logger)
        {
            _restClient = restClient;
            _importantObjectRepository = importantObjectRepository;
            _logger = logger;
        }
        public int Add(int a, int b)
        {
            _logger.LogInformation("Logged message");
            var value = _restClient.Get(new RestRequest($"add?a={a}&b={b}", Method.GET));
            var sum = a + b;

            _importantObjectRepository.Insert(sum);

            return Convert.ToInt32(sum);
        }

        public int Multiply(int a, int b)
        {
            var value = _restClient.Get(new RestRequest($"multiply?a={a}&b={b}", Method.GET));
            var product = a * b;

             _importantObjectRepository.Insert(product);


            return Convert.ToInt32(product);
        }

        public int Divide(int a, int b)
        {
            var value = _restClient.Get(new RestRequest($"divide?a={a}&b={b}", Method.GET));
            var quotient = a / b;

             _importantObjectRepository.Insert(quotient);

            return Convert.ToInt32(quotient);
        }
    }
}
