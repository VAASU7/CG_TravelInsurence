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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InsuranceCompanyContext _context;
        private readonly IMapper _mapper;  // Assuming AutoMapper is used

        public CustomerRepository(InsuranceCompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            var customer = await _context.Customers.ToListAsync();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customer);
        }

        public async Task<CustomerDTO> CreateCustomer(CustomerDTO customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            var result = await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerDTO>(result.Entity);
        }

        public async Task<CustomerDTO> UpdateCustomer(CustomerDTO customerDto)
        {/*
            var badge = _mapper.Map<Badge>(badgeDto);
            _context.Badges.Update(badge);
            await _context.SaveChangesAsync();
            var custObj = _mapper.Map<Badge>(badgeDto);
            var result = await _context.Badges.AddAsync(custObj);
            await _context.SaveChangesAsync();*/
            var existingCustomer = await _context.Customers
            .FirstOrDefaultAsync(b => b.CustomerId == customerDto.CustomerID);

            if (existingCustomer == null)
            {
                return null; // Or throw an exception if the badge doesn't exist
            }

            _mapper.Map(customerDto, existingCustomer);
            _context.Customers.Update(existingCustomer);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerDTO>(existingCustomer);
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }

        }
    }
}