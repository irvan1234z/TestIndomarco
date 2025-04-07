using Microsoft.EntityFrameworkCore;
using ProjectCustomer.Application.Models;
using ProjectCustomer.Application.Interfaces;
using ProjectCustomer.Domain.Entities;
using ProjectCustomer.Infrastructure;

namespace ProjectCustomer.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ProjectCustomerDbContext _context;

    public CustomerService(ProjectCustomerDbContext context)
    {
        _context = context;
    }

    #region GetRows
    public async Task<IEnumerable<Customer>> GetAllAsync() => await _context.Customer.ToListAsync();
    #endregion

    #region GetRowByID
    public async Task<Customer?> GetByIdAsync(int id) => await _context.Customer.FindAsync(id);
    #endregion

    #region Insert
    public async Task<Customer> CreateAsync(CustomerModel model)
    {
        var customer = new Customer
        {
            CustomerCode = model.CustomerCode,
            CustomerName = model.CustomerName,
            CustomerAddress = model.CustomerAddress,
            CreatedBy = model.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Customer.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }
    #endregion

    #region UpdateByID
    public async Task<bool> UpdateAsync(int id, CustomerModel model, int modifiedBy)
    {
        var customer = await _context.Customer.FindAsync(id);
        if (customer == null) return false;

        customer.CustomerCode = model.CustomerCode;
        customer.CustomerName = model.CustomerName;
        customer.CustomerAddress = model.CustomerAddress;
        customer.ModifiedBy = modifiedBy;
        customer.ModifiedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }
    #endregion

    #region DeleteByID
    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await _context.Customer.FindAsync(id);
        if (customer == null) return false;

        _context.Customer.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }
    #endregion
}
