using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Travel_Insurance.DTO;
using Travel_Insurance.Model;

namespace Travel_Insurance.Repository
{
    public interface IPaymentRepository
    {
        Task<PaymentDTO> GetByIdAsync(int id);
        Task<IEnumerable<PaymentDTO>> GetAllAsync();
        Task<PaymentDTO> CreatePayment(PaymentDTO PaymentDto);
        Task<PaymentDTO> UpdatePayment(PaymentDTO PaymentDto);
        Task DeleteAsync(int id);
    }
}