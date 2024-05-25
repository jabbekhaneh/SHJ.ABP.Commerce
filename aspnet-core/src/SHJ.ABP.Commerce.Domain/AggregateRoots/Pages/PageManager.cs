using JetBrains.Annotations;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Services;

namespace SHJ.ABP.Commerce.AggregateRoots.Pages;

public class PageManager : DomainService
{
    private IPageRepository PageRepository { get; }
    protected IQueryable<Page> Pages { get; }
    //____________________________________________________________
    public PageManager(IPageRepository pageRepository)
    {
        PageRepository = pageRepository;
        Pages = pageRepository.GetQueryableAsync().Result;
    }
    //____________________________________________________________
    public virtual async Task<Page> NewAsync([NotNull] string title,
                                                [CanBeNull] string? content = "",
                                                [CanBeNull] string? script = "",
                                                [CanBeNull] string? style = "")
    {
        Check.NotNullOrEmpty(title, nameof(title));

        await CheckPageTitleAsync(title);

        return new Page(GuidGenerator.Create(),
                        title, content, script, style, CurrentTenant.Id);
    }
    //____________________________________________________________
    public virtual async Task<Page> SetHomePageAsync(Page page)
    {
        var homePage = await GetHomePageAsync();

        if (!page.IsHomePage)
        {
            if (homePage != null)
            {
                homePage.SetIsHomePage(false);
                await PageRepository.UpdateAsync(homePage);
            }

            homePage = await PageRepository.GetAsync(page.Id);
        }

        homePage.SetIsHomePage(!page.IsHomePage);
        await PageRepository.UpdateAsync(homePage);

        return homePage;
    }
    //____________________________________________________________
    public virtual async Task<Page> GetHomePageAsync()
    {
        var currentHomePages = await PageRepository.GetListOfHomePagesAsync();

        if (currentHomePages.Count > 1)
        {
            throw new BusinessException(CommerceDomainErrorCodes.Pages.CanBeOnlyHomePage);
        }

        return currentHomePages.FirstOrDefault();
    }
    //____________________________________________________________
    public virtual async Task CheckPageTitleAsync([NotNull] string title)
    {
        if (await PageRepository.IsExistByTitle(title))
            throw new BusinessException(CommerceDomainErrorCodes.Pages.DublicateTitle);
    }
    //____________________________________________________________
    public virtual async Task<IQueryable<Page>> GetQueryableAsync([CanBeNull] string filter = "", [CanBeNull] string sorting = "")
    {
        IQueryable<Page> query = await PageRepository.GetQueryableAsync();
        query = query.WhereIf(!filter.IsNullOrWhiteSpace(),
            _ => _.Title.ToLower().Contains(filter.ToLower()))
        .OrderBy(sorting.IsNullOrEmpty() ? nameof(Page.Title) : sorting);
        return query;
    }
    //____________________________________________________________
    public virtual async Task<Page> GetByIdAsync(Guid id)
    {
        var page = await PageRepository.GetByIdAsync(id);
        if (page == null)
            throw new BusinessException(CommerceDomainErrorCodes.Pages.PageNotFound);
        return page;
    }

}