using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryGraphic
    {
        static Random _random = new Random();

        public static Graphic RandomCreate()
        {
            return new Graphic()
            {
                GraphicId = Guid.NewGuid(),
                Name = nameof(Graphic.Name),
                Description = nameof(Graphic.Description),
                GraphicType = FactoryGraphicType.RandomCreate(),
                Width = _random.Next(),
                Height = _random.Next()
            };
        }
    }
}
