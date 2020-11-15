using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tracker.DataAccess.Entities;
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
            var documentDto = fixture.Create<DocumentFormDto>();

            // Act
            var httpResponseMessage = await httpClient.PostAsync("documents", ObjectToJsonContent(documentDto));

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, httpResponseMessage.StatusCode);
        }

        [TestMethod]
        public async Task CreateDocument_ParameterDocumentDtoValid_EntityCreatedCorrectly()
        {
            // Arrange
            var documentDto = fixture.Create<DocumentFormDto>();

            // Act
            await httpClient.PostAsync("documents", ObjectToJsonContent(documentDto));

            // Assert
            TrackerContext.Documents.FirstOrDefault()
                .Should().BeEquivalentTo(documentDto);
        }


        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        public async Task Report_ParameterCategoryIsNullOrEmpty_ReturnBadRequest(string category)
        {
            // Arrange
            // Act
            var httpResponseMessage = await httpClient.GetAsync($"documents/report?category={category}");

            // Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task Report_CategoryNotHaveDocuments_ReturnEmptyList()
        {
            // Arrange
            var category = fixture.Create<string>();

            // Act
            var httpResponseMessage = await httpClient.GetAsync($"documents/report?category={category}");
            string json = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonToObject<IList<DocumentDto>>(json);

            // Assert
            result.Should().BeEmpty();
        }

        [TestMethod]
        public async Task Report_CategoryHaveDocuments_ReturnExpectedList()
        {
            // Arrange
            var documentWithSameCategory1 = fixture.Build<Document>()
                .With(entity => entity.Processes, new List<Process>())
                .Create();
            var documentWithSameCategory2 = fixture.Build<Document>()
                .With(entity => entity.Processes, new List<Process>())
                .With(entity => entity.Category, documentWithSameCategory1.Category).Create();
            var documentWithSameCategory3 = fixture.Build<Document>()
                .With(entity => entity.Processes, new List<Process>())
                .With(entity => entity.Category, documentWithSameCategory1.Category).Create();
            
            var documentWithDifferentCategory = fixture.Build<Document>()
                .With(entity => entity.Processes, new List<Process>())
                .Create();

            TrackerContext.Add(documentWithSameCategory1);
            TrackerContext.Add(documentWithSameCategory2);
            TrackerContext.Add(documentWithSameCategory3);
            TrackerContext.Add(documentWithDifferentCategory);
            TrackerContext.SaveChanges();

            var document1Process = fixture.Build<Process>()
                .With(entity => entity.DocumentId, documentWithSameCategory1.Id)
                .With(entity => entity.Document, documentWithSameCategory1)
                .Create();

            TrackerContext.Add(document1Process);
            TrackerContext.SaveChanges();

            var expected = new List<Document>()
            {
                documentWithSameCategory1,
                documentWithSameCategory2,
                documentWithSameCategory3
            };

            // Act
            var httpResponseMessage = await httpClient.GetAsync($"documents/report?category={documentWithSameCategory1.Category}");
            string json = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonToObject<IList<DocumentDto>>(json);

            // Assert
            result.Should().BeEquivalentTo(expected, x => x.Excluding(x => x.Processes));
        }
    }
}
