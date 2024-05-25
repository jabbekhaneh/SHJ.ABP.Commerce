using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SHJ.ABP.Commerce.AggregateRoots.Posts;

public interface IPostRepository : IRepository<Post, Guid>
{
    Task<string> GenerateCodeAsync();
}
