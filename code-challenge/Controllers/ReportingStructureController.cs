using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace challenge.Controllers
{
    [Route("api/reportingstructure")]
    public class ReportingStructureController : Controller
    {
        private readonly ILogger _logger;
        private readonly IReportingStructureService _reportingStructureService;
        private readonly IEmployeeService _employeeService;

        public ReportingStructureController(ILogger<EmployeeController> logger, IReportingStructureService reportingStructureService,IEmployeeService employeeService)
        {
            _logger = logger;
            _reportingStructureService = reportingStructureService;
            _employeeService = employeeService;
        }

        [HttpGet("{id}", Name = "getReportingStructureById")]
        public IActionResult getReportingStructureById(String id)
        {
            _logger.LogDebug($"Received employee get request for '{id}'");

            var reportingStructure = _reportingStructureService.getReportingStructureById(id);

            if (reportingStructure == null)
                return NotFound();

            return Ok(reportingStructure);
        }
    }
}
