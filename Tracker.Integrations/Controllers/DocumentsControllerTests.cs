using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Net;
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

        [TestMethod]
        public async Task CreateDocument_ParameterDocumentDtoValid_EntityCreatedCorrectly()
        {
            // Arrange
            var documentDto = fixture.Create<DocumentDto>();

            // Act
            await httpClient.PostAsync("documents", ObjectToJsonContent(documentDto));

            // Assert
            TrackerContext.Documents.FirstOrDefault()
                .Should().BeEquivalentTo(documentDto);
        }
    }
}
