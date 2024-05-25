using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace SHJ.ABP.Commerce.Controllers;

public class HomeController : AbpController
{
    //#Amazing-6670
    public ActionResult Index()
    {
        return Redirect("~/swagger");
    }
}
