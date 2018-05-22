using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryElementType
    {
        public static ElementType RandomCreate()
        {
            return new ElementType()
            {
                ElementTypeId = Guid.NewGuid(),
                Name = nameof(Scene.Name),
                Description = nameof(Scene.Description)
            };
        }
    }
}