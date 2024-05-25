using Microsoft.EntityFrameworkCore;
using SHJ.ABP.Commerce.AggregateRoots.Posts;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SHJ.ABP.Commerce.EntityFrameworkCore.Blogs;

public class EfCoreBlogRepository : EfCoreRepository<CommerceDbContext, Post, Guid>, IPostRepository
{
    public EfCoreBlogRepository(IDbContextProvider<CommerceDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<string> GenerateCodeAsync()
    {
        IQueryable<Post> query = await GetDbSetAsync();
        int count = query.IgnoreQueryFilters().Count();
        string code = $"PO{count + 1}-{Guid.NewGuid().ToString().Replace("-", " ").Substring(0, 5)}";
        while (await query.AnyAsync(m => m.Code == code))
        {
            code = $"PO{count + 1}-{Guid.NewGuid().ToString().Replace("-", " ").Substring(0, 5)}";
        }
        return code;

    }
}