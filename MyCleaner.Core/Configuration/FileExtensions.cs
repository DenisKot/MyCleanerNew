using System.Collections.Generic;

namespace MyCleaner.Core.Configuration
{
    public static class FileExtensions
    {
        public static List<string> GetFileExtenshions()
        {
            List<string> list = new List<string>();
            
            list.Add("*.tmp");
            list.Add("*.log");
            list.Add("*.bak");
            list.Add("*.chk");
            list.Add("*.~*");

            //// Junk temporary file
            list.Add("*.jnk");
            
            //// Generally cache file
            list.Add("*.cache");

            //// Lock file
            /* Files with lock extension can be often 
             * found as various database "lock" 
             * files that prevent two users to access and change same database at the same time. 
             */
            // list.Add("*.lock");

            //// Adobe Photoshop file browser thumbnail cache file
            // list.Add("*.tb0");

            //// Steam Client temporary file
            // list.Add("*.steamstart");

            //// Temporary file
            list.Add("*.temp");

            //// SQLite temporary database file
            // list.Add("*.db-wal");

            //// SQLite temporary database file
            // list.Add("*.db-shm");

            //// Memory dump, screen dump, junk files
            list.Add("*.dmp");

            //// Installation file -- see only devexpress files
            // list.Add("*.installstate");


            //// Windows
            //// Microsoft Office/Outlook crash report file
            list.Add("*.cvr");

            //// Microsoft Windows trace log file
            list.Add("*.etl");
            
            //// Microsoft Office 2013 installation file
            //list.Add("*.tt2");

            //// Microsoft Windows registry changes temporary file
            list.Add("*.regtrans-ms");

            //// Microsoft Windows registry file
            //list.Add("*.blf");

            //// Windows Installer temporary file
            //list.Add("*.rra");

            //// Microsoft Office cache file
            //list.Add("*.fsf");

            //// Other
            //// WinSCP temporary transfer file FTP files
            // list.Add("*.filepart");
            
            return list;
        }
    }
}
