using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Tracker.Services.Models;
using Tracker.DataAccess.Entities;

namespace Tracker.Integrations.Controllers
{
    [TestClass]
    public class ProcessesControllerTests : Tests
    {
        [TestMethod]
        public async Task GetProcesses_DocumentIdNotExistent_ReturnNotFound()
        {
            // Arrange
            var documentId = fixture.Create<int>();

            // Act
            var httpResponseMessage = await httpClient.GetAsync($"documents/{documentId}/processes");

            // Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task GetProcesses_DocumentIdExistsWithoutProcesses_ReturnEmptyList()
        {
            // Arrange
            var document = fixture.Build<Document>()
                .With(entity => entity.Processes, (IList<Process>)null)
                .Create();

            TrackerContext.Documents.Add(document);
            TrackerContext.SaveChanges();

            // Act
            var httpResponseMessage = await httpClient.GetAsync($"documents/{document.Id}/processes");
            string json = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonToListObject<ProcessDto>(json);

            // Assert
            result.Should().BeEmpty();
        }

        [TestMethod]
        public async Task GetProcesses_DocumentIdExistsWithProcesses_ReturnExpectedList()
        {
            // Arrange
            var document = fixture.Create<Document>();

            TrackerContext.Documents.Add(document);
            TrackerContext.SaveChanges();

            // Act
            var httpResponseMessage = await httpClient.GetAsync($"documents/{document.Id}/processes");
            string json = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonToListObject<ProcessDto>(json);

            // Assert
            result.Should().BeEquivalentTo(document.Processes);
        }


        [TestMethod]
        public async Task CreateProcess_ParameterDocumentIdNotExists_ReturnBadRequest()
        {
            // Arrange
            var documentId = fixture.Create<int>();
            var processDto = fixture.Create<ProcessDto>();

            // Act
            var httpResponseMessage = await httpClient.PostAsync($"documents/{documentId}/processes", ObjectToJsonContent(processDto));

            // Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task CreateProcess_ValidParameters_ReturnCreated()
        {
            // Arrange
            var document = fixture.Build<Document>()
                .With(entity => entity.Processes, (IList<Process>)null)
                .Create();

            TrackerContext.Add(document);
            TrackerContext.SaveChanges();

            var processDto = fixture.Create<ProcessDto>();

            // Act
            var httpResponseMessage = await httpClient.PostAsync($"documents/{document.Id}/processes", ObjectToJsonContent(processDto));

            // Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
