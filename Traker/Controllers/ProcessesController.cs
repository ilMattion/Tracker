using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tracker.Services.Contracts;
using Tracker.Services.Models;

namespace Tracker.Controllers
{
    [ApiController]
    [Route("documents/{documentIdentifier}")]
    public class ProcessesController : ControllerBase
    {
        private readonly IDocumentService documentService;

        public ProcessesController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        /// <summary>
        /// This API let you get all processes by its document.
        /// </summary>
        /// <param name="documentIdentifier"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("processes")]
        public ActionResult<IEnumerable<ProcessDto>> GetProcesses(int documentIdentifier)
        {
            if (!documentService.Exists(documentIdentifier))
            {
                return NotFound();
            }

            IEnumerable<ProcessDto> result = documentService.GetProcesses(documentIdentifier);

            return Ok(result);
        }

        /// <summary>
        /// This API let you create one process.
        /// </summary>
        /// <param name="documentIdentifier"></param>
        /// <param name="processDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("processes")]
        public IActionResult CreateProcess(int documentIdentifier, [FromBody] ProcessFormDto processDto)
        {
            if (!documentService.Exists(documentIdentifier))
            {
                return BadRequest();
            }

            documentService.CreateProcess(documentIdentifier, processDto);

            return Created($"documents/{documentIdentifier}/processes", processDto);
        }
    }
}
