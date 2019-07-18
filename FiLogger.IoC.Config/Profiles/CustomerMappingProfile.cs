using AutoMapper;
using vm = PlinxPlanner.API.DataContracts;
using dm = PlinxPlanner.Common;

namespace PlinxPlanner.IoC.Config.Profiles
{
    public class CustomerMappingProfile :Profile
    {
        public CustomerMappingProfile()
        {   
            CreateMap<dm.Models.Customer, vm.Response.Customer>();
            CreateMap<dm.Models.Customer, vm.Request.CustomerPostRequest>().ReverseMap();

            CreateMap<dm.Models.CustomerAddress, vm.Response.CustomerAddress>();
            CreateMap<dm.Models.CustomerAddress, vm.Request.CustomerAddressPostRequest>().ReverseMap();

            CreateMap<dm.Models.Sitedetails, vm.Response.Sitedetails>();
            CreateMap<dm.Models.Sitedetails, vm.Request.SiteDetailsPostrequest>().ReverseMap();
        }
    }
}

