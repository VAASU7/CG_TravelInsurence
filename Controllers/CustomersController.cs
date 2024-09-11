using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel_Insurance.DTO;
using Travel_Insurance.Model;
using Travel_Insurance.Repository;

namespace Travel_Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository CustomerRepository;
        private readonly IMapper mapper;

        public CustomerController(ICustomerRepository _CustomerRepository, IMapper _mapper)
        {
            CustomerRepository = _CustomerRepository;
            mapper = _mapper;
        }



        // GET: api/Badges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetByIdAsync(int id)
        {
            var Customer = await CustomerRepository.GetByIdAsync(id);
            if (Customer == null)
            {
                return NotFound();
            }

            return Ok(Customer);
        }

        // GET: api/Badge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllAsync()
        {
            var customer = await CustomerRepository.GetAllAsync();
            return Ok(customer);
        }

        // POST: api/Badge
        [HttpPost]
        public async Task<ActionResult> PostAsync(CustomerDTO customerDto)
        {

            var result = await CustomerRepository.CreateCustomer(customerDto);
            return Ok(result);
        }



        // PUT: api/Badge/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, CustomerDTO CustomerDto)
        {
            if (CustomerDto == null || CustomerDto.CustomerID != id)
            {
                return BadRequest();
            }

            var existingCustomer = await CustomerRepository.GetByIdAsync(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            var res = await CustomerRepository.UpdateCustomer(CustomerDto);
            return Ok(new { Message = "Record updated successfully.", UpdatedRecord = res });
        }

        // DELETE: api/Badge/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var existingCustomer = await CustomerRepository.GetByIdAsync(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            await CustomerRepository.DeleteAsync(id);

            return NoContent();
        }

    }
}