using _0_FrameWork.Domain;
using AccountManagement.Application.Contracts.Role;
using System.Collections.Generic;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<long, Role>
    {
        List<RoleViewModel> List();
        EditRole GetDetails(long id);
    }
}
