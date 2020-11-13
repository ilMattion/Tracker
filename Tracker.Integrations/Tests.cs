using AutoFixture;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Tracker.Integrations
{
    public abstract class Tests
    {
        protected Fixture fixture;
        protected HttpClient httpClient;
        protected WebApplicationFactory<Startup> WebApplicationFactory;

        [TestInitialize]
        public void Initialize()
        {
            fixture = new Fixture();
            WebApplicationFactory = new WebApplicationFactory<Startup>();
            httpClient = WebApplicationFactory.Server.CreateClient();
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
