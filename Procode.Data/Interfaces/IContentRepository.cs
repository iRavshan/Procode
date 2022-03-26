using Procode.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data.Interfaces
{
    public interface IContentRepository
    {
        Task<Content> GetById(Guid Id);
        Task<IEnumerable<Content>> GetAll();
        Task<Content> LastContent();
        Task<Content[]> LastContents(int count);
        Task<IEnumerable<Content>> SearchContent(string text);
    }
}
