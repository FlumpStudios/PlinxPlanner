using AutoMapper;
using PlinxPlanner.Service.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using vm = PlinxPlanner.API.DataContracts;
using dm = PlinxPlanner.Common.Models;
using PlinxPlanner.API.Tests.MockData;
using PlinxPlanner.Common.Extensions;
using PlinxPlanner.IoC.Config.Profiles;
using Microsoft.AspNetCore.Mvc;
using PlinxPlanner.API.Controllers.V1;
using PlinxPlanner.Service.Services;

namespace PlinxPlanner.Tests.Controllers.V1
{
    [TestClass]
    public class CustomerControllerTests
    {
        const int _TEST_RECORD_ID = 1;
        private MockRepository mockRepository;

        private readonly IMapper _mapper;
        private Mock<ICustomerService> mockCustomerService;

        public CustomerControllerTests()
        {
            //Inject in mapping profile
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<CustomerMappingProfile>();
            });
            _mapper = new Mapper(config);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockCustomerService = mockRepository.Create<ICustomerService>();

            mockCustomerService.Setup(x => x.GetCustomer(_TEST_RECORD_ID)).Returns(Task.FromResult(MockCustomerData.MockCustomerDetails_dm()));
            mockCustomerService.Setup(x => x.GetCustomerAddress(_TEST_RECORD_ID)).Returns(Task.FromResult(MockAddressData.MockCustomerAddress_List_dm()));
            mockCustomerService.Setup(x => x.GetCustomer()).Returns(Task.FromResult(MockCustomerData.MockCustomerDetailsList_dm()));

            mockCustomerService.Setup(x => x.CreateCustomer(It.IsAny<dm.Customer>())).Returns(Task.FromResult(MockCustomerData.MockCustomerDetails_dm()));
            mockCustomerService.Setup(x => x.CreateCustomerAddress(_TEST_RECORD_ID, It.IsAny<dm.CustomerAddress>())).Returns(Task.FromResult(MockAddressData.MockCustomerAddress_dm()));
            
            mockCustomerService.Setup(x => x.DeleteCustomerDetails(_TEST_RECORD_ID)).Returns(Task.FromResult(true));

            mockCustomerService.Setup(x => x.UpdateCustomerDetails(_TEST_RECORD_ID, It.IsAny<dm.Customer>())).Returns(Task.FromResult(true));
        }

        private CustomerController CreateCustomerController()
        {
            return new CustomerController(
                _mapper,
                mockCustomerService.Object);
        }

        #region get request
        [TestMethod]
        public async Task Get_CustomerDataListFromService_ShouldMapAndReturnCustomerList()
        {
            // Arrange
            var unitUnderTest = CreateCustomerController();
            var expected = MockCustomerData.MockCustomerDetailsList_vm();

            // Act
            var actual = await unitUnderTest.Get();
            
            // Assert
            Assert.IsTrue(expected.CompareByValue(actual.Value));
        }

        [TestMethod]
        public async Task Get_CustomerDataFromService_ShouldMapAndReturnAcustomerByID()
        {         
            // Arrange
            var unitUnderTest = CreateCustomerController();
            var expected = MockCustomerData.MockCustomerDetails_vm();
            int id = _TEST_RECORD_ID;

            // Act
            var actual = await unitUnderTest.Get(id);           

            // Assert
            Assert.IsTrue(expected.CompareByValue(actual.Value));
        }

        [TestMethod]
        public async Task GetAddresses_CustomerAddressDataFromService_ShouldMapAndReturnAcustomerAddressByCustomerID()
        {
            // Arrange
            var unitUnderTest = CreateCustomerController();
            var expected = MockAddressData.MockCustomerAddress_List_vm();
            int id = _TEST_RECORD_ID;

            // Act
            var actual = await unitUnderTest.GetAddresses(id);

            // Assert
            Assert.IsTrue(expected.CompareByValue(actual.Value));
        }
        #endregion


        #region Post request
        [TestMethod]
        public async Task Post_CustomerDataFromClient_ShouldRequestAddingCustomerRecordFromService()
        {
            InitaliseMapper();

            // Arrange
            var unitUnderTest = CreateCustomerController();
            var expected = MockCustomerData.MockPostRequestModel();

            // Act
            var actual = await unitUnderTest.Post(
                expected);

            // Assert
            if (actual.Result.GetType() != typeof(CreatedAtActionResult))
            {
                Assert.Fail();
            };
        }

        [TestMethod]
        public async Task Post_CustomerAddressFromClient_ShouldRequestAddingCustomerAddressFromService()
        {
            InitaliseMapper();

            // Arrange
            var unitUnderTest = CreateCustomerController();
            var expected = MockAddressData.MockCustomerAddress_vm_postrequest();

            // Act
            var actual = await unitUnderTest.PostCustomerAddress(_TEST_RECORD_ID,
                expected);

            // Assert
            if (actual.Result.GetType() != typeof(CreatedAtActionResult))
            {
                Assert.Fail();
            };
        }

        #endregion

        #region Put request
        [TestMethod]
        public async Task Put_CustomerDataFromClient_ShouldRequestUpdateCustomerRecordFromService()
        {
            InitaliseMapper();

            // Arrange
            var unitUnderTest = CreateCustomerController();
            int id = _TEST_RECORD_ID;
            vm.Request.CustomerPostRequest customerDetails = MockCustomerData.MockPostRequestModel();

            // Act
            var actual = await unitUnderTest.Put(
                id,
                customerDetails);

            // Assert
            if (actual.GetType() != typeof(OkObjectResult))
            {
                Assert.Fail();
            };
        }


        #endregion


        #region Delete request
        [TestMethod]
        public async Task Delete_CustomerDataFromClient_ShouldRequestDeleteFromService()
        {
            // Arrange
            var unitUnderTest = CreateCustomerController();
            int id = _TEST_RECORD_ID;

            // Act
            IActionResult actual = await unitUnderTest.Delete(
                id);

            //Assert
            if (actual.GetType() != typeof(OkObjectResult))
            {
                Assert.Fail();
            };
        }

        #endregion


        private static void InitaliseMapper()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CustomerMappingProfile>();
            });
        }
    }
}
