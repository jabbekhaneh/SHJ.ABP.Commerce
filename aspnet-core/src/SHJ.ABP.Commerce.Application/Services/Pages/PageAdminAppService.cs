using SHJ.ABP.Commerce.AggregateRoots.Pages;
using SHJ.ABP.Commerce.Contracts.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SHJ.ABP.Commerce.Services.Pages;


public class PageAdminAppService : CrudAppService<Page, PageDto, Guid, GetPagesInputDto, CreatePageInputDto, UpdatePageInputDto>, IPageAdminAppService
{
    private PageManager PageManager { get; }

    public PageAdminAppService(IRepository<Page, Guid> repository, PageManager pageManager) : base(repository)
    {
        PageManager = pageManager;
    }

    //_________________________________________________________
    
    public override async Task<PagedResultDto<PageDto>> GetListAsync(GetPagesInputDto input)
    {
        var query = await PageManager.GetQueryableAsync(input.Filter ?? "", input.Sorting ?? "");

        var pagings = query.PageBy(input.SkipCount * input.MaxResultCount, input.MaxResultCount)
            .OrderByDescending(_ => _.LastModificationTime).ToList();
        var count = await Repository.CountAsync();
        return new PagedResultDto<PageDto>(
          count,
           ObjectMapper.Map<List<Page>, List<PageDto>>(pagings));
    }
    //_________________________________________________________
    public override Task<PageDto> GetAsync(Guid id)
    {
        return base.GetAsync(id);
    }
    //_________________________________________________________
    
    public override async Task<PageDto> CreateAsync(CreatePageInputDto input)
    {
        var newPage = await PageManager.NewAsync(input.Title, input.Content, input.Script, input.Style);
        await Repository.InsertAsync(newPage);
        return ObjectMapper.Map<Page, PageDto>(newPage);
    }
    //_________________________________________________________
    
    public override async Task<PageDto> UpdateAsync(Guid id, UpdatePageInputDto input)
    {
        var page = await Repository.GetAsync(id);

        if (page.Title != input.Title)
            await PageManager.CheckPageTitleAsync(input.Title);

        page.SetTitle(input.Title);
        page.SetContent(input.Content);
        page.SetScript(input.Script);
        page.SetStyle(input.Style);

        await Repository.UpdateAsync(page);
        return ObjectMapper.Map<Page, PageDto>(page);
    }
    //_________________________________________________________
    public override async Task DeleteAsync(Guid id)
    {
        var page = await Repository.GetAsync(id);
        await Repository.DeleteAsync(page);
    }
    //_________________________________________________________
    
    public virtual async Task SetAsHomePageAsync(Guid id)
    {
        var page = await Repository.GetAsync(id);
        await PageManager.SetHomePageAsync(page);
    }
    //_________________________________________________________
}
