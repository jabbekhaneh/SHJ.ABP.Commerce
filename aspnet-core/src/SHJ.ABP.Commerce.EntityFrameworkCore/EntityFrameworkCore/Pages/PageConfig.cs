using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHJ.ABP.Commerce.AggregateRoots.Pages;
using System;

namespace SHJ.ABP.Commerce.EntityFrameworkCore.Pages;

public class PageConfig : IEntityTypeConfiguration<Page>
{
    public void Configure(EntityTypeBuilder<Page> builder)
    {
        throw new NotImplementedException();
    }
}
