using System;
using System.IO;
using System.Net;
using System.Configuration;
namespace NewCDNiTaas
{
    public class FileManager
    {
        protected string _sourceUrl { get; set; }
        protected string _targetPath { get; set; }
        protected string _temporaryPath { get; set; }
        protected string _temporaryFileName { get; set; }

        public FileManager(string sourceUrl, string targetPath)
        {
            _sourceUrl = sourceUrl;
            _targetPath = targetPath;
            _temporaryPath = ConfigurationManager.AppSettings["tempPath"];
        }

        public void GetFileFromWeb()
        {
            _temporaryFileName = Guid.NewGuid().ToString() + ".txt";

            if (!Directory.Exists(_temporaryPath))
                Directory.CreateDirectory(_temporaryPath);

            try
            {
                using (WebClient getter = new WebClient())
                    File.WriteAllBytes(_temporaryPath + _temporaryFileName, getter.DownloadData(_sourceUrl));

            }
            catch (Exception)
            { throw; }
        }

        public string[] GetFileLines()
        {
            return File.ReadAllLines(_temporaryPath + _temporaryFileName);
        }

        public void WriteFile(string convertedFileContent)
        {
            File.WriteAllText(_targetPath, convertedFileContent);
        }

        public void Dispose()
        {
            if (File.Exists(_temporaryPath + _temporaryFileName))
                File.Delete(_temporaryPath + _temporaryFileName);
        }
    }
}
