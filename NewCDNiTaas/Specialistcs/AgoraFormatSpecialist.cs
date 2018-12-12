using NewCDNiTaas.Helper;
using NewCDNiTaas.interfaces;
using System.Collections.Generic;

namespace NewCDNiTaas.Specialistcs
{
    public class AgoraFormatSpecialist : IFinalFormat
    {
        public List<string> Order { get; set; }

        public AgoraFormatSpecialist()
        {
            Order = new List<string>();
            Order.Add(Constants.Fields.provider);
            Order.Add(Constants.Fields.httpmethod);
            Order.Add(Constants.Fields.statuscode);
            Order.Add(Constants.Fields.uripath);
            Order.Add(Constants.Fields.timetaken);
            Order.Add(Constants.Fields.responsesize);
            Order.Add(Constants.Fields.cachestatus);
        }
    }
}
