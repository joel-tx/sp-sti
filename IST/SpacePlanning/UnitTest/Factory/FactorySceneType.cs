using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactorySceneType
    {
        public static SceneType RandomCreate()
        {
            return new SceneType()
            {
                SceneTypeId = Guid.NewGuid(),
                Name = nameof(Scene.Name),
                Description = nameof(Scene.Description)
            };
        }
    }
}