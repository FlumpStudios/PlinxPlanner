using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlinxPlanner.Common.Extensions;
using PlinxPlanner.API.Tests.MockData;

namespace PlinxPlanner.Tests.Extensions
{
    [TestClass]
    public class ObjectExtensionsTests
    {

        /// <summary>
        /// Test to ensure the compareByValue extension is working as it should
        /// </summary>
        [TestMethod]
        public void CompareByValue_Object_ShouldCompareObjectByValue()
        {

            //Use same model to ensure data is the same
            var expected = MockCustomerData.MockCustomerDetails_dm();
            var actual = MockCustomerData.MockCustomerDetails_dm();

            // Act
            bool result = expected.CompareByValue(actual);
            
            // Assert
            Assert.IsTrue(result);
         }

        
        /// <summary>
        /// Reverse test to ensure objects with non-value equlity will return false
        /// </summary>
        [TestMethod]
        public void CompareByValue_Object_Should_Fail_CompareObjectByValue()
        {
            // Arrange
            var expected = MockCustomerData.MockCustomerDetails_dm();
            var actual = MockCustomerData.MockCustomerDetails_dm();

            //Change object to ensure they are different
            actual.CustomerId++;

            // Act
            bool result = expected.CompareByValue(actual);
            
            // Assert
            Assert.IsFalse(result);
        }
    }
}
