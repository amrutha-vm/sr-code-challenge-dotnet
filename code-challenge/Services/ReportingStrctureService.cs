using System;
using System.Collections.Generic;
using challenge.Models;
using challenge.Repositories;
using Microsoft.Extensions.Logging;

namespace challenge.Services
{
    public class ReportingStrctureService:IReportingStructureService

    {
        private readonly ILogger<IReportingStructureService> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public ReportingStrctureService(ILogger<IReportingStructureService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }


        public ReportingStructure getReportingStructureById(String id)
        {
            Employee employee = _employeeRepository.GetById(id);
            ReportingStructure reportingStructure = new ReportingStructure();
            reportingStructure.Employee = employee;
            int count = 0;
            if (employee != null)
            {
                List<Employee> directreports = employee.DirectReports;
                if (directreports != null)
                {
                    for (int i=0;i<directreports.Count;i++)
                       
                    {
                            Employee report = directreports[i];
                        if (report != null )
                        {
                            count = count+1;
                            if (report.DirectReports != null) {
                                directreports.AddRange(report.DirectReports);
                            }
                        }
                            

                    }
                }
            }
            reportingStructure.NumberOfReports = count;
            return reportingStructure;
        }
    }
}
