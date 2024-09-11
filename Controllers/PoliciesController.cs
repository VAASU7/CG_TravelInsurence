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
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyRepository PolicyRepository;
        private readonly IMapper mapper;

        public PolicyController(IPolicyRepository _PolicyRepository, IMapper _mapper)
        {
            PolicyRepository = _PolicyRepository;
            mapper = _mapper;
        }



        // GET: api/Badges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyDTO>> GetByIdAsync(int id)
        {
            var policy = await PolicyRepository.GetByIdAsync(id);
            if (policy == null)
            {
                return NotFound();
            }

            return Ok(policy);
        }

        // GET: api/Badge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyDTO>>> GetAllAsync()
        {
            var policy = await PolicyRepository.GetAllAsync();
            return Ok(policy);
        }

        // POST: api/Badge
        [HttpPost]
        public async Task<ActionResult> PostAsync(PolicyDTO policyDto)
        {

            var result = await PolicyRepository.CreatePolicy(policyDto);
            return Ok(result);
        }



        // PUT: api/Badge/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, PolicyDTO policyDto)
        {
            if (policyDto == null || policyDto.PolicyID != id)
            {
                return BadRequest();
            }

            var existingPolicy = await PolicyRepository.GetByIdAsync(id);
            if (existingPolicy == null)
            {
                return NotFound();
            }

            var res = await PolicyRepository.UpdatePolicy(policyDto);
            return Ok(new { Message = "Record updated successfully.", UpdatedRecord = res });
        }

        //  public async Task<ActionResult> PutAsync(int id, CustomerDTO CustomerDto)
        // {
        //     if (CustomerDto == null || CustomerDto.CustomerID != id)
        //     {
        //         return BadRequest();
        //     }

        //     var existingCustomer = await CustomerRepository.GetByIdAsync(id);
        //     if (existingCustomer == null)
        //     {
        //         return NotFound();
        //     }

        //     var res = await CustomerRepository.UpdateCustomer(CustomerDto);
        //     return Ok(new { Message = "Record updated successfully.", UpdatedRecord = res });
        // }


        // DELETE: api/Badge/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var existingPolicy = await PolicyRepository.GetByIdAsync(id);
            if (existingPolicy == null)
            {
                return NotFound();
            }

            await PolicyRepository.DeleteAsync(id);

            return NoContent();
        }

    }
}