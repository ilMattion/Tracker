using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Tracker.Models;
using Tracker.Services.Contracts;
using Tracker.Services.Models;

namespace Tracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService documentService;
        private readonly ILogger<DocumentsController> _logger;

        public DocumentsController(IDocumentService documentService, ILogger<DocumentsController> logger)
        {
            this.documentService = documentService;
            _logger = logger;
        }


        [HttpPost]
        public IActionResult CreateDocument([FromBody] DocumentDto documentDto)
        {
            int documentId = documentService.Create(documentDto);
            return Created($"/documents/{documentId}", documentDto);
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
