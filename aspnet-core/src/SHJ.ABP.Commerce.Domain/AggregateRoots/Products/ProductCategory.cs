using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SHJ.ABP.Commerce.AggregateRoots.Products;


public class ProductCategory : FullAuditedAggregateRoot<Guid>
{
    public ProductCategory()
    {
            
    }
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public Guid? ParentId { get; set; }
}
