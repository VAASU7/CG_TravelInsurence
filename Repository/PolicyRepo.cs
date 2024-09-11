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
    public class PolicyRepository : IPolicyRepository
    {
        private readonly InsuranceCompanyContext _context;
        private readonly IMapper _mapper;  // Assuming AutoMapper is used

        public PolicyRepository(InsuranceCompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PolicyDTO> GetByIdAsync(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            return _mapper.Map<PolicyDTO>(policy);
        }

        public async Task<IEnumerable<PolicyDTO>> GetAllAsync()
        {
            var policy = await _context.Policies.ToListAsync();
            return _mapper.Map<IEnumerable<PolicyDTO>>(policy);
        }

        public async Task<PolicyDTO> CreatePolicy(PolicyDTO policyDto)
        {
            var policy = _mapper.Map<Policy>(policyDto);
            var result = await _context.Policies.AddAsync(policy);
            await _context.SaveChangesAsync();
            return _mapper.Map<PolicyDTO>(result.Entity);
        }

        public async Task<PolicyDTO> UpdatePolicy(PolicyDTO policyDto)
        {/*
            var badge = _mapper.Map<Badge>(badgeDto);
            _context.Badges.Update(badge);
            await _context.SaveChangesAsync();
            var custObj = _mapper.Map<Badge>(badgeDto);
            var result = await _context.Badges.AddAsync(custObj);
            await _context.SaveChangesAsync();*/
            var existingPolicy = await _context.Policies
            .FirstOrDefaultAsync(b => b.PolicyId == policyDto.PolicyID);

            if (existingPolicy == null)
            {
                return null; // Or throw an exception if the badge doesn't exist
            }

            _mapper.Map(policyDto, existingPolicy);
            _context.Policies.Update(existingPolicy);
            await _context.SaveChangesAsync();

            return _mapper.Map<PolicyDTO>(existingPolicy);
        }

        public async Task DeleteAsync(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy != null)
            {
                _context.Policies.Remove(policy);
                await _context.SaveChangesAsync();
            }

        }
    }
}