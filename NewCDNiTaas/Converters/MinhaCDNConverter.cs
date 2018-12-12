using NewCDNiTaas.interfaces;
using System;
using System.Collections;
using System.Text;
using static NewCDNiTaas.Helper.Constants;

namespace NewCDNiTaas
{
    public class MinhaCDNConverter : IFormatConverter
    {
        public string Provider { get { return ConverterProvidersNames.MinhaCDN; } }
        public char Separator { get { return '|'; } }
        public Hashtable ComplexPositions { get; set; }
        public Hashtable SimplePositions { get; set; }
        protected IFinalFormat FinalFormatSpecialist { get; set; }

        public MinhaCDNConverter(IFinalFormat to)
        {
            FinalFormatSpecialist = to;

            SimplePositions = new Hashtable();
            SimplePositions.Add(Fields.responsesize, 0);
            SimplePositions.Add(Fields.statuscode, 1);
            SimplePositions.Add(Fields.cachestatus, 2);
            SimplePositions.Add(Fields.timetaken, 4);

            ComplexPositions = new Hashtable();
            ComplexPositions.Add(Fields.httpmethod, 0);
            ComplexPositions.Add(Fields.uripath, 1);
            ComplexPositions.Add(Fields.protocol, 2);
        }

        public string HeaderBuilder()
        {
            return string.Format("# Version: {0}\n# Date: {1}\n# Fields: {2}\n", "1.0", string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now), string.Join(" ", FinalFormatSpecialist.Order.ToArray()));
        }

        public string FooterBuilder()
        {
            return null;
        }

        public string Converter(string[] originalFileLines)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var line in originalFileLines)
            {
                foreach (string position in FinalFormatSpecialist.Order)
                {
                    sb.Append(" ");
                    sb.Append(FormatAdapter(line, position));
                    sb.Append(" ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public string FormatAdapter(string originalLine, string position)
        {
            if (SimplePositions.Contains(position))
                return SimpleAdapter(originalLine, position);
            else if (ComplexPositions.Contains(position))
                return ComplexAdapter(originalLine, position);
            else if (position.ToLower() == Fields.provider)
                return Provider;
            else
                return string.Format("Field {0} not found", position);
        }

        public string SimpleAdapter(string originalLine, string position)
        {
            return originalLine.Split(Separator)[Convert.ToInt32(SimplePositions[position].ToString())];
        }
        public string ComplexAdapter(string originalLine, string position)
        {
            return originalLine.Split(Separator)[3].Split(' ')[Convert.ToInt32(ComplexPositions[position].ToString())].Replace("\"", ""); ;
        }

    }
}
