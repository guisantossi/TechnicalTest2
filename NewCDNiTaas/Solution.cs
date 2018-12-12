using NewCDNiTaas.Helper;
using NewCDNiTaas.interfaces;
using NewCDNiTaas.Specialistcs;

namespace NewCDNiTaas
{

    public class Solution
    {
        public IFormatConverter ConverterSpecialist { get; set; }
        protected IFinalFormat FinalFormatSpecialist { get; set; }

        public string Start(string url, string path, string typeFrom, string typeTo)
        {
            if (Validator.StartIsValid(url, path, typeFrom, typeTo))
            {
                FileManager fm = new FileManager(url, path);
                fm.GetFileFromWeb();

                if (typeTo == Constants.FinalFormatNames.Agora || string.IsNullOrEmpty(typeTo))
                    FinalFormatSpecialist = new AgoraFormatSpecialist();

                if (typeFrom == Constants.ConverterProvidersNames.MinhaCDN || string.IsNullOrEmpty(typeFrom))
                    ConverterSpecialist = new MinhaCDNConverter(FinalFormatSpecialist);

                Converter convert = new Converter(ConverterSpecialist);
                string converted = convert.Execute(fm.GetFileLines());

                fm.WriteFile(converted);
                fm.Dispose();

                return "Conversion completed";
            }
            else
                return "Something is wrong\nCheck out the parameters"; ;

        }
    }
}
