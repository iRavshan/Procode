using Procode.Data.Interfaces;
using Procode.Data.Requests;
using Procode.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly HttpClient httpClient;

        public FeedbackRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task Create(Feedback feedback)
        {
            await httpClient.PostAsJsonAsync(httpClient.BaseAddress + FeedbackAPI.Create, feedback);   
        }
    }
}
