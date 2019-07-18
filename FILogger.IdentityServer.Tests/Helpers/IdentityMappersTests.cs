using IdentityServer.Helpers;
using IdentityServer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace FILogger.IdentityServer.Tests.Helpers
{
    [TestClass]
    public class IdentityMappersTests
    {
        [TestMethod]
        public void MapIdentityResources_StateUnderTest_ExpectedBehavior()
        {
            //Arrange
            var obj = JsonConvert.DeserializeObject<IdentityConfigModel>(Mocks.MockIdentitySettingsJSON);

            //Act
            var actual = IdentityMappers.MapIdentityResources(obj.ApiResources);
            var serialisedActual = JsonConvert.SerializeObject(actual);

            //Assert            
            Assert.AreEqual(Mocks.ExpectedResourcesJsonAfterMap, serialisedActual,"Mapping values are incorrect. Please check regression");
           
        }

        [TestMethod]
        public void MapIdentityClients_StateUnderTest_ExpectedBehavior()
        {
            //Arrange
            var obj = JsonConvert.DeserializeObject<IdentityConfigModel>(Mocks.MockIdentitySettingsJSON);

            //Act
            var actual = IdentityMappers.MapIdentityClients(obj.Clients);

            var serialisedActual = JsonConvert.SerializeObject(actual);

            //Assert
            Assert.AreEqual(Mocks.ExpectedClientsJsonAfterMap, serialisedActual, "Mapping values are incorrect. Please check regression");

        }
    }
}
