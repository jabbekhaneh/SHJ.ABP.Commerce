using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SHJ.ABP.Commerce.AggregateRoots.Pages;

//public class PageDataSeedContributor : IDataSeedContributor, ITransientDependency
//{
//    private readonly IRepository<Page, Guid> _repository;
//    public PageDataSeedContributor(IRepository<Page, Guid> repository)
//    {
//        _repository = repository;
//    }

//    public async Task SeedAsync(DataSeedContext context)
//    {
//        if (await _repository.GetCountAsync() > 0)
//            return;

//        await _repository.InsertAsync(new Page("Home", "<h1>Home</h2>"));

//    }
//}
