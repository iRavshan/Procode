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
    public class ContentRepository : IContentRepository
    {
        private readonly HttpClient httpClient;

        public ContentRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Content>> GetAll()
        {
            var res = await httpClient.GetFromJsonAsync<Content[]>(httpClient.BaseAddress + ContentAPI.GetAll);
            return res;
        }

        public async Task<Content> GetById(Guid Id)
        {
            var res = await httpClient.GetFromJsonAsync<Content>(httpClient.BaseAddress + ContentAPI.GetById + Id);
            return res;
        }

        public async Task<Content> LastContent()
        {
            var res = await httpClient.GetFromJsonAsync<Content>(httpClient.BaseAddress + ContentAPI.LastContent);
            return res;
        }

        public async Task<Content[]> LastContents(int count)
        {
            var res = await httpClient.GetFromJsonAsync<Content[]>(httpClient.BaseAddress + ContentAPI.LastContents + count);
            return res;
        }

        public async Task<IEnumerable<Content>> SearchContent(string text)
        {
            IEnumerable<Content> allContents = Enumerable.Reverse(await GetAll());

            IEnumerable<string> TextOfSearch = text.Split();

            IEnumerable<Content> results = new List<Content>();

            foreach (string item in TextOfSearch)
            {
                results = results.Concat(allContents.Where(w => w.Tag.ToLower().Contains(item.ToLower())));
                results = results.Concat(allContents.Where(w => w.AuthorFirstname.ToLower().Contains(item.ToLower())));
                results = results.Concat(allContents.Where(w => w.AuthorLastname.ToLower().Contains(item.ToLower())));
                results = results.Concat(allContents.Where(w => w.Name.ToLower().Contains(item.ToLower())));
                //results = results.Concat(allContents.Where(w => w.Text.ToLower().Contains(item.ToLower())));
                results = results.Concat(allContents.Where(w => w.ShortDescription.ToLower().Contains(item.ToLower())));
            }

            return results;
        }
    }
}
