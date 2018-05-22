using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryName
    {
        static Random _random = new Random();

        public static Name RandomCreate()
        {
            return new Name()
            {
                NameId = Guid.NewGuid(),
                First = nameof(Name.First) + _random.Next(),
                Last = nameof(Name.Last),
                Middle = nameof(Name.Middle),
                Prefix = nameof(Name.Prefix),
                Suffix = nameof(Name.Suffix)
            };
        }
    }
}