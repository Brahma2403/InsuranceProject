using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insuranceDA_lib.Repositories
{
    public interface IRepositoryPolicy<T> where T : class
    {
        bool CreatePolicy(T entity);
        bool UpdatePolicy(T entity);
        bool DeletePolicy(T entity);
        List<T> GetPolicy();    
       
        T Get(object id);
    }
}
