using PlinxPlanner.Common.Settings;
using PlinxPlanner.API.Tests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PlinxPlanner.Common.Extensions;

namespace PlinxPlanner.Tests.Extensions
{
    [TestClass]
    public class SettingsExtensionsTests
    {
        [TestMethod]
        public void IsValid_AppSettings_ShouldCheckAppSettingsAreValid()
        {
            //Arrange
            var mockSettings = MockJson.mockAppSettings;
            AppSettings appSettings = JsonConvert.DeserializeObject<AppSettings>(mockSettings);

            //Act 
            var isAppsettingsValid = appSettings.IsValid();

            //Assert
            Assert.IsTrue(isAppsettingsValid.Item1, string.Format("Mock appsettings are not valid. Please check regression. Error description = {0}", isAppsettingsValid.Item2));            
        }

        [TestMethod]
        public void IsValid_AppSettings_Should_Fail_CheckAppSettingsAreValid()
        {
            //Arrange
            AppSettings appSettings = null;

            //Act 
            var isAppsettingsValid = appSettings.IsValid();

            Assert.IsFalse(isAppsettingsValid.Item1,"Appsettings isvalid extension is returning true when no settings have been passed.");

            if (string.IsNullOrEmpty(isAppsettingsValid.Item2))
            {
                Assert.Fail("Appsettings isvalid extension appears to be failing correctly but no exception message is being passed back by the tuple");
            }
        }
    }
}
