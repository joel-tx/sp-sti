using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryOperationPermission
    {
        public static OperationPermission RandomCreate()
        {
            return new OperationPermission()
            {
                Operation = FactoryOperation.RandomCreate(),
                Permission = FactoryPermission.RandomCreate()
            };
        }
    }
}
