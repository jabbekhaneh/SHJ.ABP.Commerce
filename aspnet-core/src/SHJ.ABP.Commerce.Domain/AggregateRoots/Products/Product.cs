using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SHJ.ABP.Commerce.AggregateRoots.Products;

public class Product : FullAuditedAggregateRoot<Guid>
{
    public Product(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; }
    public long Rate { get; set; }
}
