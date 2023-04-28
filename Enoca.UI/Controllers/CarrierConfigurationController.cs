using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enoca.Business.Abstract;
using Enoca.Business.ViewModels.Carrier;
using Enoca.Business.ViewModels.CarrierConfiguration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationController : ControllerBase
    {
        private readonly ICarrierConfigurationService carrierConfigurationService;

        public CarrierConfigurationController(ICarrierConfigurationService carrierConfigurationService)
        {
            this.carrierConfigurationService = carrierConfigurationService;
        }
        [HttpGet("GetAll")]
        public IEnumerable<GetCarrierConfigurationVM> GetAllCarrierConfigurations()
        {
            return carrierConfigurationService.GetAll();
        }
        [HttpPost("Create")]
        public string CreateCarrierConfiguration(CreateCarrierConfigurationVM createCarrierConfigurationVM)
        {
            return carrierConfigurationService.Add(createCarrierConfigurationVM);

        }
        [HttpPut("Update")]
        public string UpdateCarrierConfiguraton(UpdateCarrierConfigurationVM updateCarrierConfigurationVM)
        {
            return carrierConfigurationService.Update(updateCarrierConfigurationVM);
        }
        [HttpGet("Delete/{id}")]
        public string DeleteCarrierConfiguraiton(int id)
        {
            return carrierConfigurationService.Delete(id);
        }
    }
}
