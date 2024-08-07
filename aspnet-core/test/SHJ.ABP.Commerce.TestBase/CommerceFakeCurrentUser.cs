﻿using System;
using System.Security.Claims;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace SHJ.ABP.Commerce;

public class CommerceFakeCurrentUser : ITransientDependency ,ICurrentUser
{
    private readonly CommerceTestData _commerceTestData;

    public CommerceFakeCurrentUser(CommerceTestData commerceTestData)
    {
        _commerceTestData = commerceTestData;
    }

    public bool IsAuthenticated { get; }
    public Guid? Id => _commerceTestData.User1Id;
    public string UserName => _commerceTestData.User1UserName;
    public string Name { get; }
    public string SurName { get; }
    public string PhoneNumber { get; }
    public bool PhoneNumberVerified { get; }
    public string Email { get; }
    public bool EmailVerified { get; }
    public Guid? TenantId { get; }
    public string[] Roles { get; }

    public Claim FindClaim(string claimType)
    {
        return null;
    }

    public Claim[] FindClaims(string claimType)
    {
        return null;
    }

    public Claim[] GetAllClaims()
    {
        return null;
    }

    public bool IsInRole(string roleName)
    {
        return false;
    }
}
