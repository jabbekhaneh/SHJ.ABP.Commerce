using System;
using Volo.Abp.Application.Dtos;

namespace SHJ.ABP.Commerce.Contracts.Identity.Users;

public class AssignableRolesDto : EntityDto<Guid>
{
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
    public bool IsStatic { get; set; }
    public bool IsPublic { get; set; }
    public bool IsAssignable { get; set; }
   

}
