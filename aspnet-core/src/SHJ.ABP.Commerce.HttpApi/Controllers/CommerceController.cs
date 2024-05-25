using Microsoft.AspNetCore.Mvc;
using SHJ.ABP.Commerce.Localization;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace SHJ.ABP.Commerce.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CommerceController : AbpControllerBase
{
    protected CommerceController()
    {
        LocalizationResource = typeof(CommerceResource);
    }

    
}
