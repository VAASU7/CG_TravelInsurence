using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Travel_Insurance.DTO;
using Travel_Insurance.Model;
using System;


namespace Travel_Insurance.Repository
{
    public interface IClaimRepository 
    {
        Task<Claim1DTO> GetByIdAsync(int id);
        Task<IEnumerable<Claim1DTO>> GetAllAsync();
        Task<Claim1DTO> CreateClaim(Claim1DTO claim1Dto);
        Task<Claim1DTO> UpdateClaim(Claim1DTO claim1Dto);
        Task DeleteAsync(int id);
    }
}