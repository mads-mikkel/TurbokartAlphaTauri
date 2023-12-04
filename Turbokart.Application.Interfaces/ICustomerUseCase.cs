using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbokart.Domain.Entities;

namespace Turbokart.Application.Interfaces
{
    public interface ICustomerUseCase
    {
        Task<Customer> GetCustomer(int id);
        Task<IEnumerable<Customer>> GetAllCustomers();
    }
}
