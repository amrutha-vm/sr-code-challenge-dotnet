using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using challenge.Data;

namespace challenge.Repositories
{
    public class CompensationRepository:ICompensationRepository

    {

        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<ICompensationRepository> _logger;

        public CompensationRepository(ILogger<ICompensationRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        public Compensation createCompensation(Compensation compensation)
        {

            compensation.Employee = _employeeContext.Employees.ToList().SingleOrDefault(e => e.EmployeeId == compensation.Employee.EmployeeId);
            if(compensation.Employee !=null){
                compensation.CompensationId = Guid.NewGuid().ToString();
               _employeeContext.Compensations.Add(compensation);
                return compensation;
            }
            else {
                return null;
            };
        }

        public Compensation getCompensationByEmployeeId(string id)
        {
         return _employeeContext.Compensations.FirstOrDefault(e => e.Employee.EmployeeId == id);

        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }

        public Compensation Remove(Compensation compensation)
        {
            return _employeeContext.Remove(compensation).Entity;
        }
    }
}
