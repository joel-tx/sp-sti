using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryGraphicType
    {
        public static GraphicType RandomCreate()
        {
            return new GraphicType()
            {
                GraphicTypeId = Guid.NewGuid(),
                Name = nameof(Graphic.Name),
                Description = nameof(Graphic.Description)
            };
        }
    }
}
