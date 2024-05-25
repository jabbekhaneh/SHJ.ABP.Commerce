using AutoMapper;
using SHJ.ABP.Commerce.AggregateRoots.Pages;
using SHJ.ABP.Commerce.Contracts.Identity.AuditLogs;
using SHJ.ABP.Commerce.Contracts.Identity.IdentitySecurityLogs;
using SHJ.ABP.Commerce.Contracts.Pages;
using Volo.Abp.AuditLogging;
using Volo.Abp.Identity;

namespace SHJ.ABP.Commerce;

public class CommerceApplicationAutoMapperProfile : Profile
{
    public CommerceApplicationAutoMapperProfile()
    {
        
        #region Pages
        CreateMap<Page, PageDto>();
        #endregion

        #region Identity
        CreateMap<AuditLog, AuditLogDto>();
        CreateMap<IdentitySecurityLog, IdentitySecurityLogDto>();
        #endregion



    }
}
