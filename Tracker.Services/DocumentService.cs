using AutoMapper;
using System;
using Tracker.DataAccess.Contracts;
using Tracker.DataAccess.Entities;
using Tracker.Services.Contracts;
using Tracker.Services.Models;

namespace Tracker.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IMapper mapper;
        private readonly IDocumentRepository documentRepository;

        public DocumentService(IMapper mapper, IDocumentRepository documentRepository)
        {
            this.mapper = mapper;
            this.documentRepository = documentRepository;
        }

        public int Create(DocumentDto document)
        {
            Document entity = mapper.Map<Document>(document);
            return documentRepository.Create(entity);
        }
    }
}
