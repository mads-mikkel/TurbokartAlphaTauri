using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbokart.Application.Interfaces;
using Turbokart.Domain.Entities;
using Turbokart.Infrastructure.Persistence.Interfaces;

namespace Turbokart.Application.UseCases
{
    public class CustomerUseCase : ICustomerUseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Customer>> GetAllCustomers()
        {
            ICustomerRepository customerRepository = unitOfWork.CustomerRepository;
            return customerRepository.GetAll();
        }

        public Task<Customer> GetCustomer(int id)
        {
            ICustomerRepository customerRepository = unitOfWork.CustomerRepository;
            return customerRepository.GetBy(id);
        }
    }
}
