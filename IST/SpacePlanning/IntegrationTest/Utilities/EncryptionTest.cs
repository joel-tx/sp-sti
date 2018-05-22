using STP.SpacePlanning.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IST.SpacePlanning.IntegrationTest.Utilities
{
    public class EncryptionTest
    {
        [Fact]
        public void ShouldEncryptPasswordWhenUsingSHA256Algorithm()
        {
            string password = "MyPassword123";
            Assert.NotEqual<string>(password, Encryption.Encrypt(password));
        }
    }
}
