using Procode.Data.DTO;
using Procode.Data.DTO.Requests;
using Procode.Data.DTO.Responses;
using Procode.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid Id);
        Task Update(User user);
        Task Delete(Guid Id);
        Task<AuthResponse> Login(UserLoginRequest userRequest);
        Task<AuthResponse> Register(UserRegisterRequest userRequest);
    }
}
