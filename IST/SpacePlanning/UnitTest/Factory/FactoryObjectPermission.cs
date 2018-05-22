using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryObjectPermission
    {
        public static ObjectPermission RandomCreate()
        {
            return new ObjectPermission()
            {
                Object = FactoryObject.RandomCreate(),
                Permission = FactoryPermission.RandomCreate()
            };
        }
    }
}
