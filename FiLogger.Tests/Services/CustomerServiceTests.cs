using PlinxPlanner.Common.Models;
using PlinxPlanner.DataAccess.Contracts;
using PlinxPlanner.Service.Services;
using PlinxPlanner.API.Tests.MockData;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using PlinxPlanner.Common.Extensions;
using PlinxPlanner.DataAccess.Contracts.RepositoryContracts;
using PlinxPlanner.DataAccess.EntityFramework;
using PlinxPlanner.Caching;
using System.Collections.Generic;

namespace PlinxPlanner.Tests.Services
{
    [TestClass]
    public class CustomerServiceTests
    {
        const int _TEST_RECORD_ID = 1;

        private MockRepository mockRepository;

        private Mock<ICustomerRepository> mockCustomerRepository;
        private Mock<ILogger<CustomerService>> mockLogger;
        private Mock<ICachingManager> mockCachingManager;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository(MockBehavior.Default);
            mockLogger = mockRepository.Create<ILogger<CustomerService>>();

            mockCustomerRepository = mockRepository.Create<ICustomerRepository>();
            mockCachingManager = mockRepository.Create<ICachingManager>();


            mockCustomerRepository.Setup(x => x.GetCustomer()).Returns(Task.FromResult(MockCustomerData.MockCustomerDetailsList_dm()));
            mockCustomerRepository.Setup(x => x.GetCustomer(_TEST_RECORD_ID)).Returns(Task.FromResult(MockCustomerData.MockCustomerDetails_dm()));
            mockCustomerRepository.Setup(x => x.GetCustomerAddress(_TEST_RECORD_ID)).Returns(Task.FromResult(MockAddressData.MockCustomerAddress_List_dm()));
            
            mockCustomerRepository.Setup(x => x.UpdateCustomer(MockCustomerData.MockCustomerDetails_dm()));
            
            mockCustomerRepository.Setup(x => x.DeleteCustomer(_TEST_RECORD_ID));
            
            mockCustomerRepository.Setup(x => x.AddCustomer(It.IsAny<Customer>())).Returns(MockCustomerData.MockCustomerDetails_dm);
            mockCustomerRepository.Setup(x => x.AddCustomerAddress(It.IsAny<CustomerAddress>())).Returns(MockAddressData.MockCustomerAddress_dm());
            
            mockCustomerRepository.Setup(x => x.CustomerDetailsExists(_TEST_RECORD_ID)).Returns(true);            

        }

        private CustomerService CreateService()
        {
            return new CustomerService(
                mockCachingManager.Object,
                mockCustomerRepository.Object,  
                mockLogger.Object);
        }

        #region Test Get Methods
        [TestMethod]
        public async Task GetCustomerDetails_CustomerDetailsList_ShouldReturnListOfCustomersFromRepo()
        {
            // Arrange
            var unitUnderTest = CreateService();
            var expected = MockCustomerData.MockCustomerDetailsList_dm();

            // Act
            var actual = await unitUnderTest.GetCustomer();
            
            // Assert
            Assert.IsTrue(expected.CompareByValue(actual));

        }

        [TestMethod]
        public async Task GetCustomerDetails_CustomerDetails_ShouldReturnCustomerByIdFromRepo()
        {
            // Arrange
            var unitUnderTest = CreateService();
            const int id = _TEST_RECORD_ID;
            var expected = MockCustomerData.MockCustomerDetails_dm();

            // Act
            var actual = await unitUnderTest.GetCustomer(
                id);

            // Assert
            Assert.IsTrue(expected.CompareByValue(actual));
        }

        [TestMethod]
        public async Task GetCustomerAddress_CustomerAddress_ShouldReturnCustomersAddressByCustomerIdFromRepo()
        {
            // Arrange
            var unitUnderTest = CreateService();
            const int id = _TEST_RECORD_ID;
            var expected = MockAddressData.MockCustomerAddress_List_dm();

            // Act
            var actual = await unitUnderTest.GetCustomerAddress(
                id);

            // Assert
            Assert.IsTrue(expected.CompareByValue(actual));
        }

        
        #endregion

        #region Test update methods
        [TestMethod]
        public async Task UpdateCustomerDetails_CustomerDetail_ShouldSimulateUpdatingRecord()
        {
            // Arrange
            var unitUnderTest = CreateService();
            const int id = _TEST_RECORD_ID;
            Customer customerDetails = MockCustomerData.MockCustomerDetails_dm();
            
            // Act
            var actual = await unitUnderTest.UpdateCustomerDetails(
                id,
                customerDetails);

            // Assert
            if (!actual) Assert.Fail();
        }
  
        #endregion

        #region Test update create methods
        [TestMethod]
        public async Task CreateCustomerDetails_CustomerDetails_ShouldSimulateCreatingAcustomerRecord()
        {
            // Arrange
            var unitUnderTest = CreateService();
            var customerDetails = MockCustomerData.MockCustomerDetails_dm();


            // Act
            var actual = await unitUnderTest.CreateCustomer(
                customerDetails);

            // Assert
            if (actual.CustomerId != _TEST_RECORD_ID)
            { 
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task CreateCustomerAddress_CustomerAddress_ShouldSimulateCreatingAcustomersAddressRecord()
        {
            // Arrange
            var unitUnderTest = CreateService();
            var customerAddress = MockAddressData.MockCustomerAddress_dm();


            // Act
            var actual = await unitUnderTest.CreateCustomerAddress(_TEST_RECORD_ID,
                customerAddress);

            // Assert
            if (actual.CustomerId != _TEST_RECORD_ID)
            {
                Assert.Fail();
            }
        }

   



        #endregion

        #region Test delete Methods
        [TestMethod]
        public async Task DeleteCustomerDetails_CustomerDetails_ShouldSimulateDeletingCustomerRecord()
        {
            // Arrange
            var unitUnderTest = CreateService();
            const int id = _TEST_RECORD_ID;

            // Act
            var actual = await unitUnderTest.DeleteCustomerDetails(
                id);

            if (!actual) Assert.Fail();
        }
        #endregion


    }
}
