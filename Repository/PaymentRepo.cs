using AutoMapper;
using Travel_Insurance.DTO;
using Travel_Insurance.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; // For IEnumerable<>
using System.Threading.Tasks; // For Task<>
using Microsoft.Extensions.Logging; // For ILogger<>
using System;



namespace Travel_Insurance.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly InsuranceCompanyContext _context;
        private readonly IMapper _mapper;  // Assuming AutoMapper is used

        public PaymentRepository(InsuranceCompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaymentDTO> GetByIdAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            return _mapper.Map<PaymentDTO>(payment);
        }

        public async Task<IEnumerable<PaymentDTO>> GetAllAsync()
        {
            var payment = await _context.Payments.ToListAsync();
            return _mapper.Map<IEnumerable<PaymentDTO>>(payment);
        }

        public async Task<PaymentDTO> CreatePayment(PaymentDTO PaymentDto)
        {
            var payment = _mapper.Map<Payment>(PaymentDto);
            var result = await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return _mapper.Map<PaymentDTO>(result.Entity);
        }

        public async Task<PaymentDTO> UpdatePayment(PaymentDTO PaymentDto)
        {/*
            var badge = _mapper.Map<Badge>(badgeDto);
            _context.Badges.Update(badge);
            await _context.SaveChangesAsync();
            var custObj = _mapper.Map<Badge>(badgeDto);
            var result = await _context.Badges.AddAsync(custObj);
            await _context.SaveChangesAsync();*/
            var existingPayment = await _context.Payments
            .FirstOrDefaultAsync(b => b.PaymentId == PaymentDto.PaymentID);

            if (existingPayment == null)
            {
                return null; // Or throw an exception if the badge doesn't exist
            }

            _mapper.Map(PaymentDto, existingPayment);
            _context.Payments.Update(existingPayment);
            await _context.SaveChangesAsync();

            return _mapper.Map<PaymentDTO>(existingPayment);
        }

        public async Task DeleteAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }

        }
    }
}