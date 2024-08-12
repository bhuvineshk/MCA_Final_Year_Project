using InsuraNex.Models.Domain;

namespace InsuraNex.Repositories
{
    public interface IPolicyOpsRepository
    {
        Task<IEnumerable<InsurancePlans>> GetAllAsync();
        Task<InsurancePlans> GetAsync(Guid id);
        Task<InsurancePlans> AddAsync(InsurancePlans insurancePlan);
        Task<InsurancePlans> UpdateAsync(InsurancePlans insurancePlan);
        Task<bool> DeleteAsync(Guid id);
    }
}
