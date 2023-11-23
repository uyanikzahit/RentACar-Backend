using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var customerDetail = from c in context.Customers
                                     join u in context.Users
                                     on c.Id equals u.Id
                                     select new CustomerDetailDto
                                     {
                                         CompanyName = c.Name,
                                         CustomerId = c.Id,
                                         Email = u.Email,
                                         FirstName = u.FirstName,
                                         LastName = u.LastName
                                     };
                return customerDetail.ToList();



            }
        }
    }
}
