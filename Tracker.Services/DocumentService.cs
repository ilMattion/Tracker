﻿using AutoMapper;
using System;
using System.Collections.Generic;
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
        private readonly IProcessRepository processRepository;

        public DocumentService(IMapper mapper, IDocumentRepository documentRepository, IProcessRepository processRepository)
        {
            this.mapper = mapper;
            this.documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
            this.processRepository = processRepository ?? throw new ArgumentNullException(nameof(processRepository));
        }

        public bool Exists(int documentId)
        {
            return documentRepository.Exists(documentId);
        }

        public int Create(DocumentFormDto document)
        {
            Document entity = mapper.Map<Document>(document);
            return documentRepository.Create(entity);
        }

        public IEnumerable<ProcessDto> GetProcesses(int documentIndentifier)
        {
            var processes = processRepository.GetByDocumentId(documentIndentifier);
            return mapper.Map<IList<ProcessDto>>(processes);
        }

        public int CreateProcess(int documentIdentifier, ProcessFormDto processDto)
        {
            processDto.DocumentId = documentIdentifier;
            var process = mapper.Map<Process>(processDto);
            return processRepository.Create(process);
        }

        public IEnumerable<DocumentDto> Report(string documentCategory)
        {
            var documents = documentRepository.Report(documentCategory);
            return mapper.Map<IList<DocumentDto>>(documents);
        }

        public IEnumerable<DocumentDto> ReportByLastTimeProcess(int timeProcess)
        {
            var documents = documentRepository.ReportByLastTimeProcess(timeProcess);
            return mapper.Map<IList<DocumentDto>>(documents);
        }
    }
}
