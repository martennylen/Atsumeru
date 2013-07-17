using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Raven.Client.Document;

namespace Atsumeru
{
    public class DataDocumentStore
    {
        private static IDocumentStore _instance;

        public static IDocumentStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("IDocumentStore has not been initialized.");
                }
                return _instance;
            }
        }

        public static IDocumentStore Initialize()
        {
            _instance = new DocumentStore { ConnectionStringName = "Server" };
            //_instance.Conventions.DefaultQueryingConsistency = ConsistencyOptions.QueryYourWrites;
            _instance.Initialize();
            return _instance;
        }
    }
}