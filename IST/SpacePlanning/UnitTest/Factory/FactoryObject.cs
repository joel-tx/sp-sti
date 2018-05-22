using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryObject
    {
        static System.Random _random = new System.Random();

        public static Object RandomCreate()
        {
            return new Object()
            {
                ObjectId = System.Guid.NewGuid(),
                Name = nameof(Object.Name) + _random.Next(),
                Description = nameof(Object.Description)
            };
        }
    }
}
