using AutoMapper;
using Travel_Insurance.DTO;
using Travel_Insurance.Model;


    namespace Travel_Insurance
{
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Customer, CustomerDTO>();
                CreateMap<CustomerDTO, Customer>();
                CreateMap<Claim1, Claim1DTO>();
                CreateMap<Claim1DTO, Claim1>();
                CreateMap<Payment, PaymentDTO>();
                CreateMap<PaymentDTO, Payment>();
                CreateMap<Policy, PolicyDTO>();
                CreateMap<PolicyDTO, Policy>();
                //CreateMap<Agent, AgentDTO>();
                //CreateMap<agentDTO, Agent>();
        }
        }
    }
