﻿using Procode.Data.DTO;
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
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient client;

        public UserRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task Delete(Guid Id)
        {
           await client.DeleteAsync($"{client.BaseAddress}{Id}");
        }

        public async Task<User> GetById(Guid Id)
        {
            return await client.GetFromJsonAsync<User>($"{client.BaseAddress}{UserAPI.GetById}{Id}");
        }

        public async Task Login(UserLoginRequest userRequest)
        {
            await client.PostAsJsonAsync($"{client.BaseAddress}{UserAPI.Login}", userRequest);
        }

        public async Task Update(User user)
        {
            await client.PutAsJsonAsync($"{client.BaseAddress}{UserAPI.Update}", user);
        }
    }
}
