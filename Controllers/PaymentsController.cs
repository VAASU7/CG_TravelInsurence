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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository PaymentRepository;
        private readonly IMapper mapper;

        public PaymentController(IPaymentRepository _PaymentRepository, IMapper _mapper)
        {
            PaymentRepository = _PaymentRepository;
            mapper = _mapper;
        }



        // GET: api/Badges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDTO>> GetByIdAsync(int id)
        {
            var payment = await PaymentRepository.GetByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        // GET: api/Badge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDTO>>> GetAllAsync()
        {
            var payment = await PaymentRepository.GetAllAsync();
            return Ok(payment);
        }

        // POST: api/Badge
        [HttpPost]
        public async Task<ActionResult> PostAsync(PaymentDTO paymentDto)
        {

            var result = await PaymentRepository.CreatePayment(paymentDto);
            return Ok(result);
        }



        // PUT: api/Badge/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, PaymentDTO PaymentDto)
        {
            if (PaymentDto == null || PaymentDto.ClaimID != id)
            {
                return BadRequest();
            }

            var existingPayment = await PaymentRepository.GetByIdAsync(id);
            if (existingPayment == null)
            {
                return NotFound();
            }

            var res = await PaymentRepository.UpdatePayment(PaymentDto);
            return Ok(new { Message = "Record updated successfully.", UpdatedRecord = res });
        }

        // DELETE: api/Badge/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var existingPayment = await PaymentRepository.GetByIdAsync(id);
            if (existingPayment == null)
            {
                return NotFound();
            }

            await PaymentRepository.DeleteAsync(id);

            return NoContent();
        }

    }
}