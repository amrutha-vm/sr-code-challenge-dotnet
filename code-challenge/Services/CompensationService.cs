using System;
using challenge.Models;
using challenge.Repositories;
using Microsoft.Extensions.Logging;

namespace challenge.Services
{
    public class CompensationService:ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository, IEmployeeRepository employeeRepository)
        {
            _compensationRepository = compensationRepository;
            _employeeRepository = employeeRepository;
            _logger = logger;
        }


        public Compensation getCompensationByEmployeeId(string employeeId)
        {
            if (!String.IsNullOrEmpty(employeeId))
            {
                Employee employee = _employeeRepository.GetById(employeeId);
                Compensation compensation= _compensationRepository.getCompensationByEmployeeId(employeeId);
                if (compensation != null) {
                    compensation.Employee = employee;
                }
                
                return compensation;
            }
            return null;
        }

        public Compensation createCompensation(Compensation compensation)

        {
            if (compensation != null && compensation.Employee!=null)
            {
                _compensationRepository.createCompensation(compensation);
                _compensationRepository.SaveAsync().Wait();
            }

            return compensation;
            
        }
    }
}
