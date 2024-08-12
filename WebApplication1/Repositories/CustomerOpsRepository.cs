using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Permissions;
using InsuraNex.Data;
using InsuraNex.Models.Domain;

namespace InsuraNex.Repositories
{
    public class CustomerOpsRepository(RazorPagesDBContext razorPagesDBContext) : ICustomerOpsRepository
    {
        public async Task<Customer> AddAsync(Customer cust)
        {

            razorPagesDBContext.Customers.AddAsync(cust);
             razorPagesDBContext.SaveChanges();

            return cust;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingCustomer =  razorPagesDBContext.Customers.Find(id);

            if (existingCustomer != null)
            {
                razorPagesDBContext.Customers.Remove(existingCustomer);
                 razorPagesDBContext.SaveChanges();
                return true;
            }


            return false;
        }

        public RazorPagesDBContext? GetRazorPagesDBContext()
        {
            return razorPagesDBContext;
        }


        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return  razorPagesDBContext.Customers.ToList();


        }

        public async Task<Customer> GetAsync(Guid id)
        {
            return  razorPagesDBContext.Customers.Find(id);
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
           
            Customer? existingCustomer = (customer != null)?  razorPagesDBContext.Customers.Find(customer.Id): null;

            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.DOC = customer.DOC;
                existingCustomer.Occupation = customer.Occupation;
                existingCustomer.Plan = customer.Plan;
                existingCustomer.DOB = customer.DOB;
                existingCustomer.Plan_Exp_Date = customer.Plan_Exp_Date;
                existingCustomer.City = customer.City;
                existingCustomer.Income = customer.Income;
                existingCustomer.Contact_No = customer.Contact_No;
            }

             razorPagesDBContext.SaveChanges();

            return existingCustomer;
        }
    }
}
