﻿using Biseth.Net.Settee.Http;

namespace Biseth.Net.Settee.Couch.Api.Elements
{
    public class CouchApiDesignDocCommand : CouchApiDesignDoc
    {
        public CouchApiDesignDocCommand(RequestClient requestClient)
            : base(requestClient)
        {
        }
    }
}