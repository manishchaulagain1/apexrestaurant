using ApexRestaurant.Repository.Domain;
using ApexRestaurant.Services.SCustomer;
using Microsoft.AspNetCore.Mvc;

namespace ApexRestaurant.Api.Controller {
    [Route ("api/customer")]

    public class CustomerController : ControllerBase {
        private readonly ICustomerService _customerService;
        public CustomerController (ICustomerService customerService) {
            _customerService = customerService;
        }

        [HttpGet]
        [Route ("{id}")]
        public IActionResult Get ([FromRoute] int id) {
            var customer = _customerService.GetById (id);
            if (customer == null)
                return NotFound ();
            return Ok (customer);
        }

        [HttpGet]
        [Route ("")]
        public IActionResult GetAll () {
            System.Threading.Thread.Sleep(2500);
            var customers = _customerService.GetAll ();
            return Ok (customers);
        }

        [HttpPost]
        [Route ("")]
        public IActionResult Post ([FromBody] Customer model) {
            _customerService.Insert (model);
            return Ok ();
        }

        [HttpPut]
        [Route ("")]
        public IActionResult Put ([FromBody] Customer model) {
            _customerService.Update (model);
            return Ok ();
        }

        [HttpDelete]
        [Route ("{id}")]
        public IActionResult Delete ([FromBody] int id) {
            _customerService.Delete (id);
            return Ok ();
        }
    }
}