using System;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace IdentityServerService
{
    public class MyProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            throw new NotImplementedException();
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}