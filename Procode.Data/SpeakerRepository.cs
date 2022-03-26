using Newtonsoft.Json;
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
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly HttpClient httpClient;

        public SpeakerRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Speaker>> GetAll()
        {
            var res = await httpClient.GetFromJsonAsync<Speaker[]>(httpClient.BaseAddress + SpeakerAPI.GetAll);
            return res;
        }

        public async Task<Speaker> GetById(Guid Id)
        {
            var res = await httpClient.GetFromJsonAsync<Speaker>(httpClient.BaseAddress + SpeakerAPI.GetById + Id);
            return res;
        }
    }
}
