using NewCDNiTaas.Helper;
using System;
using System.IO;

namespace NewCDNiTaas
{
    public class Validator
    {
        public static bool StartIsValid(string url, string path, string typeFrom, string typeTo)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                return false;
            if (!PathIsValid(path))
                return false;
            if (FromIsValid(typeFrom))
                return false;
            if (ToIsValid(typeTo))
                return false;

            return true;
        }

        private static bool PathIsValid(string path)
        {
            bool valid = true;

            if (!path.ToLower().Contains(".txt"))
                valid = false;

            if (valid)
            {
                try
                {
                    if (!File.Exists(path))
                        File.Create(path);
                    if (!File.Exists(path))
                        valid = false;
                    File.Delete(path);
                }
                catch (Exception)
                {
                    valid = false;
                }
            }

            return valid;
        }

        private static bool FromIsValid(string typeFrom)
        {
            bool valid = false;
            if (typeFrom == Constants.ConverterProvidersNames.MinhaCDN)
                valid = true;
            //else if( other types that can be implemented in the future)

            return valid;
        }

        private static bool ToIsValid(string typeTo)
        {
            bool valid = false;
            if (typeTo == Constants.FinalFormatNames.Agora)
                valid = true;
            //else if( other types that can be implemented in the future)
            return valid;
        }
    }
}