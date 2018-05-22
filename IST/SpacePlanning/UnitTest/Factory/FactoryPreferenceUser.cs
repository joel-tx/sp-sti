using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryPreferenceUser
    {
        public static PreferenceUser RandomCreate()
        {
            return new PreferenceUser()
            {
                Preference = FactoryPreference.RandomCreate(),
                User = FactoryUser.RandomCreate()
            };
        }
    }
}
