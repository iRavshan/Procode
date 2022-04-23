using Procode.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAll();
        Task<Post> GetById(Guid Id);
        Task<Post> LastContent();
        Task<Post[]> LastContents(int count);
    }
}
