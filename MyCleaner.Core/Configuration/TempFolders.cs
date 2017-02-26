using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCleaner.Core.Configuration
{
    public static class TempFolders
    {
        public static List<string> GetTempFolders()
        {
            //// C:\Users\Denys
            //// Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            //// System.Environment.GetEnvironmentVariable("USERPROFILE")

            List<string> list = new List<string>();

            //// Ненужные файлы, созданые системой
            list.Add(@"C:\Windows\temp");

            //// Ненужные файлы, созданые приложениями
            list.Add(Path.GetTempPath());

            //// Отчёты об ошибкам
            // list.Add(@"C:\ProgramData\Microsoft\Windows\Caches"); ?
            list.Add(@"C:\ProgramData\Microsoft\Windows\WER\ReportArchive");
            list.Add(@"C:\ProgramData\Microsoft\Windows\WER\ReportQueue");
            list.Add(@"C:\ProgramData\Microsoft\Windows\WER\Temp");

            //// Кэш Google Chrome
            //// Google Chrome rollback journal file
            if (Directory.Exists(System.Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\Google\Chrome"))
            {
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Local Storage");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Cache\");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Application Cache\Cache");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\GPUCache");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Shortcuts-journal");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Current Tabs");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Last Tabs");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Top Sites");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\SHistory Provider Cache");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Network Action Predictor");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\History");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Visited Links");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Safe Browsing Cookies-journal");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Cookies-journal");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Favicons-journal");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\History-journal");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\QuotaManager-journal");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Shortcuts-journal");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Top Sites-journal");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Web Data-journal");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Network Action Predictor-journal");
                list.Add(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Google\Chrome\User Data\Default\Application Cache\Index-journal");
            }

            //// Кэш Mozilla FireFox
            if (Directory.Exists(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                                 @"\AppData\Local\Mozilla\Firefox\Profiles"))
            {
                foreach (var path in Directory.GetDirectories(System.Environment.GetEnvironmentVariable("USERPROFILE") +
                         @"\AppData\Local\Mozilla\Firefox\Profiles"))
                {
                    list.Add(path + @"\jumpListCache");
                    list.Add(path + @"\thumbnails");
                    list.Add(path + @"\cache2\entries");
                }
            }

            //// Недавние 
            list.Add(Environment.GetEnvironmentVariable("USERPROFILE") + @"\Recent");
            list.Add(Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Roaming\Microsoft\Windows\Recent");

            //// Windows Defender
            list.Add(@"C:\ProgramData\Microsoft\Windows Defender\Scans\History\Results\Resource");
            list.Add(@"C:\ProgramData\Microsoft\Windows Defender\Scans\History\Results\Quick");
            list.Add(@"C:\ProgramData\Microsoft\Windows Defender\Definition Updates\Backup");

            //// Explorer and IconCache
            list.Add(Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\Microsoft\Windows\Explorer");
            list.Add(Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\IconCache.db");

            //// Кэш базисных установщиков Windows
            list.Add(@"C:\Windows\Installer\$PatchCache$\");
            list.Add(@"C:\Windows\WinSxS\Backup");

            //// Данные Windows Prefetch
            list.Add(@"C:\Windows\Prefetch");

            //// Файлы в корзине
            //list.Add(@"C:\$Recycle.Bin\");

            //// Системный кэш
            list.Add(@"C:\Windows\WinSxS\ManifestCache");
            list.Add(@"C:\Windows\System32\config\systemprofile\AppData\LocalLow\Microsoft\CryptnetUrlCache\Content");

            //// Temporary location for install events
            list.Add(@"C:\Windows\WinSxS\InstallTemp");

            //// Temp directory used for various operations, you’ll find pending renames here
            list.Add(@"C:\Windows\WinSxS\Temp");

            //// Log files
            list.Add(@"C:\Windows\System32\LogFiles");

            //// Adobe flash player
            list.Add(Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Roaming\Macromedia\Flash Player");

            //// Resharper 
            list.Add(Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\JetBrains\Transient\ReSharperPlatformVs11\v04\SolutionCaches");
            list.Add(Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\JetBrains\Transient\ReSharperPlatformVs11\v04\ShellCaches");

            list.Add(Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\JetBrains\Transient\ReSharperPlatformVs14\v04\SolutionCaches");
            list.Add(Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\JetBrains\Transient\ReSharperPlatformVs14\v04\ShellCaches");

            return list;
        }
    }
}
