using Newtonsoft.Json;
using Procode.Data.DTO;
using Procode.Data.DTO.Requests;
using Procode.Data.DTO.Responses;
using Procode.Data.Interfaces;
using Procode.Data.Requests;
using Procode.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Procode.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient client;

        public UserRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task ChangePassword(ChangePasswordRequest request)
        {
            await client.PostAsJsonAsync($"{client.BaseAddress}{UserAPI.ChangePassword}", request);
        }

        public async Task Delete(string Email)
        {
           await client.DeleteAsync($"{client.BaseAddress}{Email}");
        }

        public async Task<User> GetById(Guid Id)
        {
            return await client.GetFromJsonAsync<User>($"{client.BaseAddress}{UserAPI.GetById}{Id}");
        }

        public async Task<AuthResponse> Login(UserLoginRequest userRequest)
        {
            var response = (await client.PostAsJsonAsync($"{client.BaseAddress}{UserAPI.Login}", userRequest));
            AuthResponse result = await response.Content.ReadFromJsonAsync<AuthResponse>();
            return result;
        }

        public async Task<AuthResponse> Register(UserRegisterRequest userRequest)
        {
            var response = (await client.PostAsJsonAsync($"{client.BaseAddress}{UserAPI.Register}", userRequest));
            AuthResponse result = await response.Content.ReadFromJsonAsync<AuthResponse>();
            return result;
        }

        public async Task Update(User user)
        {
            await client.PutAsJsonAsync($"{client.BaseAddress}{UserAPI.Update}", user);
        }
    }
}
