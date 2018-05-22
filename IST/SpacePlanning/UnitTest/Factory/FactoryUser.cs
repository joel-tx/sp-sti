using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public class FactoryUser
    {
        static Random _random = new Random();

        public static User RandomCreate()
        {
            return new User()
            {
                UserId = Guid.NewGuid(),
                Password = nameof(User.Password),
                Username = nameof(User.Username)
            };
        }
    }
}