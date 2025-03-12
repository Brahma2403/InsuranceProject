using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insuranceDA_lib.Repositories
{
    public interface IRepositoryCustomer<T> where T : class
    {
        bool AddCustomer(T entity);

        bool UpdateCustomer(T entity); 
        
        List<T> GetCustomerDetails();

        T Get(object obj);
    }
   
}
