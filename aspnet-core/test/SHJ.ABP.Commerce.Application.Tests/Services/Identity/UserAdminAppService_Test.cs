using SHJ.ABP.Commerce.Contracts.Identity.Users;

namespace SHJ.ABP.Commerce.Services.Identity;

public class UserAdminAppService_Test : CommerceApplicationTestBase
{
    private IUserAdminAppService _sut;
    public UserAdminAppService_Test()
    {
        _sut = GetRequiredService<IUserAdminAppService>();
    }
}
