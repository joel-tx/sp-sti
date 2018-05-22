using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryRole
    {
        public static Role RandomCreate()
        {
            return new Role()
            {
                RoleId = Guid.NewGuid(),
                Name = nameof(Role.Name),
                Description = nameof(Role.Description)
            };
        }
   }
}
