using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SHJ.ABP.Commerce.Contracts.Pages;

public interface IPageAdminAppService : ICrudAppService<PageDto, PageDto, Guid, GetPagesInputDto, CreatePageInputDto, UpdatePageInputDto>
{
    Task SetAsHomePageAsync(Guid id);
}
