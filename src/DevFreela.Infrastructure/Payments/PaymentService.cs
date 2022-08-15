using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.DTOs;
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

        public PaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _paymentBaseUrl = configuration.GetSection("Services:Payments").Value;
        }

        public async Task<bool>  ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            //chama o microsserviço de pagamento atraves do httpClient
            var url = $"{_paymentBaseUrl}/api/payments";

            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            var paymentInfoContet = new StringContent(
                    paymentInfoJson,
                    Encoding.UTF8,
                    "application/json"
                );

            var httpClient = _httpClientFactory.CreateClient("Payments");

            var response = await httpClient.PostAsync(url, paymentInfoContet);

            return response.IsSuccessStatusCode;
        }
    }
}
