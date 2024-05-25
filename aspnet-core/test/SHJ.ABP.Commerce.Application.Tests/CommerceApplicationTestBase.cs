using SHJ.ABP.Commerce.EntityFrameworkCore;
using System;

namespace SHJ.ABP.Commerce;

public abstract class CommerceApplicationTestBase : CommerceTestBase<CommerceApplicationTestModule>
{
    protected virtual void UsingDbContext(Action<CommerceDbContext> action)
    {
        using (var dbContext = GetRequiredService<CommerceDbContext>())
        {
            action.Invoke(dbContext);
        }
    }

    protected virtual T UsingDbContext<T>(Func<CommerceDbContext, T> action)
    {
        using (var dbContext = GetRequiredService<CommerceDbContext>())
        {
            return action.Invoke(dbContext);
        }
    }
}
