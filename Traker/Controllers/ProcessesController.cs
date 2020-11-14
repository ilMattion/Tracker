using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tracker.Services.Contracts;
using Tracker.Services.Models;

namespace Tracker.Controllers
{
    [ApiController]
    [Route("documents/{documentIndentifier}")]
    public class ProcessesController : ControllerBase
    {
        private readonly IDocumentService documentService;

        public ProcessesController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        [HttpGet]
        [Route("processes")]
        public ActionResult<IEnumerable<ProcessDto>> GetProcesses(int documentIndentifier)
        {
            if (!documentService.Exists(documentIndentifier))
            {
                return NotFound();
            }

            IEnumerable<ProcessDto> result = documentService.GetProcesses(documentIndentifier);

            return Ok(result);
        }

        [HttpPost]
        [Route("processes")]
        public IActionResult CreateProcess(int documentIdentifier, [FromBody] ProcessDto processDto)
        {
            return Ok();
        }
    }
}
