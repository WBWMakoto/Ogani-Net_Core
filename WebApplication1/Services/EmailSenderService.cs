using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace WebApplication1.Services
{
    public class EmailSenderService : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly RestClient _client;

        public EmailSenderService(IOptions<EmailSettings> emailOptions)
        {
            _emailSettings = emailOptions.Value;

            // Khởi tạo RestClient và truyền Authenticator vào ConstructorOptions
            var options = new RestClientOptions(_emailSettings.ApiBaseUri)
            {
                Authenticator = new HttpBasicAuthenticator("api", _emailSettings.ApiKey)
            };
            _client = new RestClient(options);
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Tạo request POST đến endpoint {domain}/messages
            var request = new RestRequest("{domain}/messages", Method.Post);
            request.AddUrlSegment("domain", _emailSettings.Domain);
            request.AddParameter("from", _emailSettings.From);
            request.AddParameter("to", email);
            request.AddParameter("subject", subject);
            request.AddParameter("html", htmlMessage);

            // Gửi request và nhận về RestResponse
            RestResponse response = await _client.ExecuteAsync(request);

            // Kiểm tra kết quả
            if (!response.IsSuccessful)
            {
                throw new InvalidOperationException($"Error sending email: {response.StatusCode} - {response.Content}");
            }
        }
    }
}
