using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insuranceDA_lib.Repositories
{
    public interface IRepositoryClaim<T> where T : class
    {
        bool SubmitClaim(T entity);
        bool ProcessClaim(T entity);
        List<T> GetClaimDetails();
        T Get(object obj);
    }
}
