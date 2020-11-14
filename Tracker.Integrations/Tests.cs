using AutoFixture;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Tracker.DataAccess;

namespace Tracker.Integrations
{
    public abstract class Tests
    {
        protected TrackerContext TrackerContext;
        protected Fixture fixture;
        protected HttpClient httpClient;
        protected CustomWebApplicationFactory WebApplicationFactory;

        [TestInitialize]
        public void Initialize()
        {
            fixture = new Fixture();
            WebApplicationFactory = new CustomWebApplicationFactory();
            httpClient = WebApplicationFactory.Server.CreateClient();
            TrackerContext = WebApplicationFactory.TrackerContext;
        }

        [TestCleanup]
        protected void Cleanup()
        {
            if (WebApplicationFactory != null)
            {
                WebApplicationFactory.Dispose();
            }
        }

        protected StringContent ObjectToJsonContent(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);

            return new StringContent
            (
                json,
                Encoding.UTF8,
                "application/json"
            );
        }
    }
}
