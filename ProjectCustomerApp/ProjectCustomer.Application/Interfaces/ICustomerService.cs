using ProjectCustomer.Application.Models;
using ProjectCustomer.Domain.Entities;

namespace ProjectCustomer.Application.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task<Customer> CreateAsync(CustomerModel model);
    Task<bool> UpdateAsync(int id, CustomerModel model, int modifiedBy);
    Task<bool> DeleteAsync(int id);
}