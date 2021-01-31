using System;
using challenge.Models;

namespace challenge.Services
{
    public interface ICompensationService
    {
        Compensation getCompensationByEmployeeId(String EmployeeId);
        Compensation createCompensation(Compensation compensation);
    }
}
