using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryPlanUser
    {
        public static PlanUser RandomCreate()
        {
            return new PlanUser()
            {
                Plan = FactoryPlan.RandomCreate(),
                User = FactoryUser.RandomCreate()
            };
        }
    }
}
