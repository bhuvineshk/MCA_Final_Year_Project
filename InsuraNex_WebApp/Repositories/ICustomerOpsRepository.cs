using InsuraNex.Models.Domain;

namespace InsuraNex.Repositories
{
    public interface ICustomerOpsRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetAsync(Guid id);
        Task<Customer> AddAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(Guid id);

    }
}
