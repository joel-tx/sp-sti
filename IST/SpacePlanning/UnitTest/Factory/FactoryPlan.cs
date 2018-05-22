using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryPlan
    {
        public static Plan RandomCreate()
        {
            return new Plan()
            {
                PlanId = Guid.NewGuid(),
                ModifyDate = DateTime.Now,
                Name = nameof(Plan.Name),
                Description = nameof(Plan.Description)
            };
        }
    }
}
