using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tracker.Services.Contracts;
using Tracker.Services.Models;

namespace Tracker.Controllers
{
    [Authorize]
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
        /// This report let you retrieve documents by its cagetories.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet("report")]
        public IActionResult Report([FromQuery] string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return BadRequest();
            }

            var result = documentService.Report(category);

            return Ok(result);
        }

        [HttpGet("report/lasttimeprocess/{timeProcess}")]
        public IActionResult ReportByLastTimeProcess(int timeProcess)
        {
            if (timeProcess < 1)
            {
                return BadRequest("The time process cannot be less than one.");
            }

            var result = documentService.ReportByLastTimeProcess(timeProcess);

            return Ok(result);
        }
    }
}
