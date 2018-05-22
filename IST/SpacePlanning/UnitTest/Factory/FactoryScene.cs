using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryScene
    {
        public static Scene RandomCreate()
        {
            return new Scene()
            {
                SceneId = Guid.NewGuid(),
                Name = nameof(Scene.Name),
                Description = nameof(Scene.Description),
                ModifyDate = DateTime.Now,
                SceneType = FactorySceneType.RandomCreate(),
                Plan = FactoryPlan.RandomCreate()
            };
        }
    }
}
