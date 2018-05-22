using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryLayer
    {
        static Random _random = new Random();

        public static Layer RandomCreate()
        {
            return new Layer()
            {
                LayerId = Guid.NewGuid(),
                Scene = FactoryScene.RandomCreate(),
                LayerType = FactoryLayerType.RandomCreate(),
                Zorder = _random.Next(),
                Name = nameof(Layer.Name),
                Description = nameof(Layer.Description)
            };
        }
   }
}
