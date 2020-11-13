using AutoFixture;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tracker.Services.Models;

namespace Tracker.Integrations.Controllers
{
    [TestClass]
    public class DocumentsControllerTests : Tests
    {
        [TestMethod]
        public async Task CreateDocument_ParameterDocumentDtoValid_ReturnCreated()
        {
            // Arrange
            var documentDto = fixture.Create<DocumentDto>();

            // Act
            var httpResponseMessage = await httpClient.PostAsync("documents", ObjectToJsonContent(documentDto));

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, httpResponseMessage.StatusCode);
        }
    }
}
