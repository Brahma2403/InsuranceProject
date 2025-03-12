using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insuranceDA_lib.Repositories
{
    public interface IRepositoryPremimumCalculation<T> where T : class
    {
        float CalculatePremium(T entity);
    }
}
