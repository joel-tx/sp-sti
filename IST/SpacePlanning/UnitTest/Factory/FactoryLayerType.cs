using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryLayerType
    {
        public static LayerType RandomCreate()
        {
            return new LayerType()
            {
                LayerTypeId = Guid.NewGuid(),
                Name = nameof(Scene.Name),
                Description = nameof(Scene.Description)
            };
        }
    }
}
