using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SHJ.ABP.Commerce.AggregateRoots.Identity.Users;

public class AppUser : FullAuditedAggregateRoot<Guid>
{
    public Guid UserId { get; set; }
}
