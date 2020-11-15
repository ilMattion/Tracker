using Microsoft.AspNetCore.Mvc;
using Tracker.Services.Contracts;
using Tracker.Services.Models;

namespace Tracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService documentService;

        public DocumentsController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        /// <summary>
        /// This API let you create one document.
        /// </summary>
        /// <param name="documentDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateDocument([FromBody] DocumentFormDto documentDto)
        {
            int id = documentService.Create(documentDto);
            return Created($"/documents/{id}", documentDto);
        }

        /// <summary>
        /// This API let you get one report of actual document.
        /// </summary>
        /// <returns></returns>
        [HttpGet("report")]
        public IActionResult Report()
        {
            var result = documentService.Report();

            return Ok(result);
        }
    }
}
