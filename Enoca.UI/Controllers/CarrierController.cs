using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enoca.Business.Abstract;
using Enoca.Business.ViewModels.Carrier;
using Enoca.Business.ViewModels.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly ICarrierService carrierService;

        public CarrierController(ICarrierService carrierService)
        {
            this.carrierService = carrierService;
        }
        [HttpGet("GetAll")]
        public IEnumerable<GetCarrierVM> GetAllCarriers()
        {
            return carrierService.GetAll();
        }
        [HttpPost("Create")]
        public string CreateCarrier(CreateCarrierVM createCarrierVM)
        {
            return carrierService.Add(createCarrierVM);

        }
        [HttpPut("Update")]
        public string UpdateCarrier(UpdateCarrierVM updateCarrierVM)
        {
            return carrierService.Update(updateCarrierVM);
        }
        [HttpGet("Delete/{id}")]
        public string DeleteCarrier(int id)
        {
            return carrierService.Delete(id);
        }
    }
}

