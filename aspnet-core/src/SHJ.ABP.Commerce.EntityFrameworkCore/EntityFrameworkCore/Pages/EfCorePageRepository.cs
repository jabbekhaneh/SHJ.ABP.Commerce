using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using SHJ.ABP.Commerce.AggregateRoots.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SHJ.ABP.Commerce.EntityFrameworkCore.Pages;

public class EfCorePageRepository : EfCoreRepository<CommerceDbContext, Page, Guid>, IPageRepository
{
    public EfCorePageRepository(IDbContextProvider<CommerceDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Page> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync()).SingleOrDefaultAsync(_ => _.Id == id, GetCancellationToken(cancellationToken));
    }

    public virtual async Task<int> GetCountAsync([CanBeNull]string filter ="",
        CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync()).WhereIf(
            !filter.IsNullOrWhiteSpace(),
            x =>
                x.Title.ToLower().Contains(filter.ToLower())
        ).CountAsync(GetCancellationToken(cancellationToken));
    }

    public Task<List<Page>> GetListOfHomePagesAsync(CancellationToken cancellationToken = default)
    {
        return GetListAsync(x => x.IsHomePage, cancellationToken: GetCancellationToken(cancellationToken));
    }

    public async Task<bool> IsExistByTitle(string title, CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync()).AnyAsync(x => x.Title == title, GetCancellationToken(cancellationToken));
    }



   

}
