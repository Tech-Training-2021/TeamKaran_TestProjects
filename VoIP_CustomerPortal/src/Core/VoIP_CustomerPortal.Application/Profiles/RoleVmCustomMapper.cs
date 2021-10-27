using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using VoIP_CustomerPortal.Application.Features.Roles.Queries.GetRoleList;
using VoIP_CustomerPortal.Domain.Entities;

namespace VoIP_CustomerPortal.Application.Profiles
{
    public class RoleVmCustomMapper : ITypeConverter<Role, RoleListVm>
    {
        private readonly IDataProtector _protector;

        public RoleVmCustomMapper(IDataProtector provider)
        {
            _protector = provider.CreateProtector("");
        }
        public RoleListVm Convert(Role source, RoleListVm destination, ResolutionContext context)
        {
            RoleListVm dest = new RoleListVm()
            {
                RoleId = System.Convert.ToInt32(_protector.Protect(source.RoleId.ToString())),
                RoleName = source.RoleName,                
            };

            return dest;
        }
    }
}
