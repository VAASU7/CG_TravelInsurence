using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Travel_Insurance.DTO;
using Travel_Insurance.Model;

namespace Travel_Insurance.Repository
{
    public interface IPolicyRepository
    {
        Task<PolicyDTO> GetByIdAsync(int id);
        Task<IEnumerable<PolicyDTO>> GetAllAsync();
        Task<PolicyDTO> CreatePolicy(PolicyDTO policyDto);
        Task<PolicyDTO> UpdatePolicy(PolicyDTO policyDto);
        Task DeleteAsync(int id);
    }
}