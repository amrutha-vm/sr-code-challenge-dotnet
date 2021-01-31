using System;
using System.Threading.Tasks;
using challenge.Models;

namespace challenge.Repositories
{
    public interface ICompensationRepository
    {
        Compensation getCompensationByEmployeeId(String employeeId);
        Compensation createCompensation(Compensation compensation);
        Task SaveAsync();

    }
}
