using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryRolePermission
    {
        public static RolePermission RandomCreate()
        {
            return new RolePermission()
            {
                Role = FactoryRole.RandomCreate(),
                Permission = FactoryPermission.RandomCreate()
            };
        }
    }
}