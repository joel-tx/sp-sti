using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryPermission
    {
        public static Permission RandomCreate()
        {
            return new Permission()
            {
                PermissionId = Guid.NewGuid(),
                Name = nameof(Permission.Name),
                Description = nameof(Permission.Description)
            };
        }
    }
}
