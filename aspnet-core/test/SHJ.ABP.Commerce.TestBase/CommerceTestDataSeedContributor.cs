using FizzWare.NBuilder;
using SHJ.ABP.Commerce.AggregateRoots.Pages;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace SHJ.ABP.Commerce;

public class CommerceTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly CommerceTestData _commerceTestData;
    private readonly IPageRepository _pageRepository;
    private readonly IAuditLogRepository _auditLogRepository;
    public CommerceTestDataSeedContributor(IGuidGenerator guidGenerator, CommerceTestData commerceTestData, IPageRepository pageRepository, IAuditLogRepository auditLogRepository)
    {
        _guidGenerator = guidGenerator;
        _commerceTestData = commerceTestData;
        _pageRepository = pageRepository;
        _auditLogRepository = auditLogRepository;
    }




    public async Task SeedAsync(DataSeedContext context)
    {


        await AuditLogAsync();
        await SeedPagesAsync();
    }

    private async Task SeedPagesAsync()
    {
        var page1 = new Page(_guidGenerator.Create(),
                             _commerceTestData.Page_1_Title,
                             _commerceTestData.Page_1_Content);
        await _pageRepository.InsertAsync(page1);

        var page2 = new Page(_guidGenerator.Create(),
                             _commerceTestData.Page_2_Title,
                             _commerceTestData.Page_2_Content);
        await _pageRepository.InsertAsync(page2);
    }

    private async Task AuditLogAsync()
    {
        var auditLog = Builder<AuditLog>.CreateNew().With(_ => _.Id,
            _commerceTestData.AuditLog.Id)
            .With(_ => _.UserId, _commerceTestData.User1Id)
            .Build();

        await _auditLogRepository.InsertAsync(auditLog);
    }
}
