using Microsoft.AspNetCore.Mvc;
using SHJ.Commerce.MVC.Common;

namespace SHJ.Commerce.MVC.Components.Header.MetaTags;

[ViewComponent(Name = "MetaTags")]
public class MetaTagsViewComponent : ViewComponent
{
    public virtual IViewComponentResult Invoke()
    {
        return View(ComponentUrls.Shared.MetaTagsDefault);
    }
}
