using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.DTOs;
using DevFreela.Core.IServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _paymentBaseUrl;

        private readonly IMessageBusService _messageBusService;
        private const string queue_name = "Payments";

        public PaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration, IMessageBusService messageBusService)
        {
            _httpClientFactory = httpClientFactory;
            _paymentBaseUrl = configuration.GetSection("Services:Payments").Value;
            _messageBusService = messageBusService;
        }

        public void  ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            /*
            //chama o microsserviço de pagamento atraves do httpClient
            //Não mais usado pois agora esta sendo usado mensageria e era feito uma chamada http
            //var url = $"{_paymentBaseUrl}/api/payments";

            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            
            var paymentInfoContet = new StringContent(
                    paymentInfoJson,
                    Encoding.UTF8,
                    "application/json"
                );

            var httpClient = _httpClientFactory.CreateClient("Payments");

            var response = await httpClient.PostAsync(url, paymentInfoContet);
            */


            //Com rabbitMq

            //transforma o paymentInfoDTO em uma string json
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            //transforma o json em bytes
            var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

            _messageBusService.Publish(queue_name, paymentInfoBytes);
 
        }
    }
}
