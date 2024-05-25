using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SHJ.ABP.Commerce.AggregateRoots.Pages;

public interface IPageRepository : IRepository<Page, Guid>
{
    Task<int> GetCountAsync(string filter = "", CancellationToken cancellationToken = default);
    Task<bool> IsExistByTitle(string title, CancellationToken cancellationToken = default);
    Task<List<Page>> GetListOfHomePagesAsync(CancellationToken cancellationToken = default);

    Task<Page> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    

}
