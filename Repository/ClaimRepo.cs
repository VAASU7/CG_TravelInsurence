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
    public class ClaimRepository : IClaimRepository
    {
        private readonly InsuranceCompanyContext _context;
        private readonly IMapper _mapper;  // Assuming AutoMapper is used

        public ClaimRepository(InsuranceCompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Claim1DTO> GetByIdAsync(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            return _mapper.Map<Claim1DTO>(claim);
        }

        public async Task<IEnumerable<Claim1DTO>> GetAllAsync()
        {
            var claim = await _context.Claims.ToListAsync();
            return _mapper.Map<IEnumerable<Claim1DTO>>(claim);
        }

        public async Task<Claim1DTO> CreateClaim(Claim1DTO claimDto)
        {
            var claim = _mapper.Map<Claim1>(claimDto);
            var result = await _context.Claims.AddAsync(claim);
            await _context.SaveChangesAsync();
            return _mapper.Map<Claim1DTO>(result.Entity);
        }

        public async Task<Claim1DTO> UpdateClaim(Claim1DTO claim1Dto)
        {/*
            var badge = _mapper.Map<Badge>(badgeDto);
            _context.Badges.Update(badge);
            await _context.SaveChangesAsync();
            var custObj = _mapper.Map<Badge>(badgeDto);
            var result = await _context.Badges.AddAsync(custObj);
            await _context.SaveChangesAsync();*/
            var existingClaim = await _context.Claims
            .FirstOrDefaultAsync(b => b.ClaimId == claim1Dto.ClaimID);

            if (existingClaim == null)
            {
                return null; // Or throw an exception if the badge doesn't exist
            }

            _mapper.Map(claim1Dto, existingClaim);
            _context.Claims.Update(existingClaim);
            await _context.SaveChangesAsync();

            return _mapper.Map<Claim1DTO>(existingClaim);
        }



        public async Task DeleteAsync(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim != null)
            {
                _context.Claims.Remove(claim);
                await _context.SaveChangesAsync();
            }

        }
    }
}