using System;
using System.IO;
using BaseUIBDD.Common;

namespace BaseUIBDD.Startup
{
    public class Startup
    {
        public Startup()
        {
            CreateScreenShotFolder();
        }

        public void Validate()
        {
            PerformExistenceCheck(CustomConfiguration.ChromeDriverPath, TypeofFile.Directory);
            PerformExistenceCheck(CustomConfiguration.GoogleChromePortable, TypeofFile.File);
            PerformExistenceCheck(CustomConfiguration.GoogleChromeDefaultProfilePath, TypeofFile.Directory);
            PerformExistenceCheck(CustomConfiguration.ScreenShotLocation, TypeofFile.Directory);
        }
        
        #region Helper Methods

        private enum TypeofFile
        {
            File,
            Directory
        }

        private static void CreateScreenShotFolder()
        {
            var screenShotFolderLocation = CustomConfiguration.ScreenShotLocation;

            if (!Directory.Exists(screenShotFolderLocation))
            {
                Directory.CreateDirectory(screenShotFolderLocation);
            }
        }

        private static void PerformExistenceCheck(string location, TypeofFile typeofFile)
        {
            if (!CheckExists(location, typeofFile))
            {
                throw new Exception("Doesn't Exist :" + location);
            }
        }

        private static bool CheckExists(string location, TypeofFile typeofFile)
        {
            var result = false;

            switch (typeofFile)
            {
                case TypeofFile.File:
                    result = File.Exists(location);
                    break;
                case TypeofFile.Directory:
                    result = Directory.Exists(location);
                    break;
            }

            return result;
        }

        #endregion
    }
}
