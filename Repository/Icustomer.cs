using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Travel_Insurance.DTO;
using Travel_Insurance.Model;
using System;


namespace Travel_Insurance.Repository
{
    public interface ICustomerRepository
    {
        Task<CustomerDTO> GetByIdAsync(int id);
        Task<IEnumerable<CustomerDTO>> GetAllAsync();
        Task<CustomerDTO> CreateCustomer(CustomerDTO customerDto);
        Task<CustomerDTO> UpdateCustomer(CustomerDTO customerDto);
        Task DeleteAsync(int id);
    }
}