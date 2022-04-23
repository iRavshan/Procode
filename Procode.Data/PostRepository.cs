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
    public class PostRepository : IPostRepository
    {
        private readonly HttpClient httpClient;

        public PostRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task Create(Post post)
        {
            await httpClient.PostAsJsonAsync(httpClient.BaseAddress + PostAPI.Create, post);
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            var res = await httpClient.GetFromJsonAsync<Post[]>(httpClient.BaseAddress + PostAPI.GetAll);
            return res;
        }

        public async Task<Post> GetById(Guid Id)
        {
            var res = await httpClient.GetFromJsonAsync<Post>(httpClient.BaseAddress + PostAPI.GetById + Id);
            return res;
        }

        public async Task<Post> LastContent()
        {
            var res = await httpClient.GetFromJsonAsync<Post>(httpClient.BaseAddress + PostAPI.LastContent);
            return res;
        }

        public async Task<Post[]> LastContents(int count)
        {
            var res = await httpClient.GetFromJsonAsync<Post[]>(httpClient.BaseAddress + PostAPI.LastContents + count);
            return res;
        }
    }
}
