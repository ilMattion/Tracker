using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Tracker.Models;

namespace Tracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly ILogger<DocumentsController> _logger;

        public DocumentsController(ILogger<DocumentsController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public IActionResult CreateDocument([FromBody] DocumentDto documentDto)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{documentIdentifier}/processes")]
        public IEnumerable<ProcessDto> GetProcesses(int documentIndentifier)
        {
            return null;
        }

        [HttpPost]
        [Route("{documentIdentifier}/processes")]
        public IActionResult CreateProcess(int documentIdentifier, [FromBody] ProcessDto processDto)
        {
            return Ok();
        }
    }
}
