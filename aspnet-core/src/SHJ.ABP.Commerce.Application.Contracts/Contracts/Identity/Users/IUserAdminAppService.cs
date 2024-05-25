using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SHJ.ABP.Commerce.Contracts.Identity.Users;

public interface IUserAdminAppService : IApplicationService
{
    Task<List<AssignableRolesDto>> GetAssignableRoles(Guid id);
    
}
