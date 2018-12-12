using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCDNiTaas.Helper
{
    public class Constants
    {
        public class FinalFormatNames
        {
            public const string Agora = "Agora";
        }
        public class ConverterProvidersNames
        {
            public const string MinhaCDN = "MinhaCDN";
        }

        public class Fields
        {
            public const string provider = "provider";
            public const string httpmethod = "http-method";
            public const string statuscode = "status-code";
            public const string uripath = "uri-path";
            public const string timetaken = "time-taken";
            public const string responsesize = "response-size";
            public const string cachestatus = "cache-status";
            public const string protocol = "protocol";
        }
    }
}
