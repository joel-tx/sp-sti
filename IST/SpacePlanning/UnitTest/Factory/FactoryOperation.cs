using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryOperation
    {
        static Random _random = new Random();

        public static Operation RandomCreate()
        {
            return new Operation()
            {
                OperationId = Guid.NewGuid(),
                Name = nameof(Operation.Name),
                Description = nameof(Operation.Description)
            };
        }
    }
}
