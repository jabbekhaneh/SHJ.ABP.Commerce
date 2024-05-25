using Microsoft.AspNetCore.Identity;
using SHJ.ABP.Commerce.Contracts.Identity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace SHJ.ABP.Commerce.Services.Identity.Users;



public class UserAdminAppService : ApplicationService, IUserAdminAppService
{
    private readonly UserManager<IdentityUser> _Manager;
    private readonly IRepository<IdentityRole> _repositoryRole;
    public UserAdminAppService(UserManager<IdentityUser> manager, IRepository<IdentityRole> repositoryRole)
    {
        _Manager = manager;
        this._repositoryRole = repositoryRole;
    }

    public async Task<List<AssignableRolesDto>> GetAssignableRoles(Guid id)
    {
        var user = await _Manager.FindByIdAsync(id.ToString());
        if (user == null) { throw new BusinessException(""); }

        var roles = await _repositoryRole.GetListAsync();

        return roles.Select(_ => new AssignableRolesDto
        {
            Id = _.Id,
            Name = _.Name,
            IsDefault = _.IsDefault,
            IsPublic = _.IsPublic,
            IsStatic = _.IsStatic,
            IsAssignable = user.Roles.Any(it => it.RoleId == _.Id)
        }).ToList();
    }
}
