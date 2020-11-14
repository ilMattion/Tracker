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
    }
}
