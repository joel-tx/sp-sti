using System;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest
{
    public static class FactoryPreference
    {
        public static Preference RandomCreate()
        {
            return new Preference()
            {
                PreferenceId = Guid.NewGuid(),
                Data = nameof(Preference.Data)
            };
        }
    }
}
