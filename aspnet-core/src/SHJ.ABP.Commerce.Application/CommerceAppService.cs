using System;
using System.Collections.Generic;
using System.Text;
using SHJ.ABP.Commerce.Localization;
using Volo.Abp.Application.Services;

namespace SHJ.ABP.Commerce;

/* Inherit your application services from this class.
 */
public abstract class CommerceAppService : ApplicationService
{
    protected CommerceAppService()
    {
        LocalizationResource = typeof(CommerceResource);
    }
}
