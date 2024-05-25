using FizzWare.NBuilder;
using SHJ.ABP.Commerce.Contracts.Identity.AuditLogs;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Xunit;

namespace SHJ.ABP.Commerce.Services.Identity;


public class AuditLoggingAdminAppService_Test : CommerceApplicationTestBase
{
    private readonly IAuditLoggingAdminAppService _sut;
    private readonly IAuditLogRepository _repository;
    private readonly CommerceTestData _data;
    public AuditLoggingAdminAppService_Test()
    {
        _sut = GetRequiredService<IAuditLoggingAdminAppService>();
        _repository = GetRequiredService<IAuditLogRepository>();
        _data = GetRequiredService<CommerceTestData>();
    }

    [Fact]
    public async Task ShouldGetListAsync()
    {
        //arrange

        
        //act
        var actual = await _sut.GetListAsync(new PagedAndSortedAuditLogDtoResultRequestDto());

        //assert
        
    }
}
