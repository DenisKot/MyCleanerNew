using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using MyCleaner.Core.Configuration;

namespace MyCleaner.Core.Business.Impl
{
    public class SearchFilesManager : Manager
    {
        private bool chechFoldersCache = false;

        public override void Work(object param)
        {
            SynchronizationContext context = (SynchronizationContext)param;

            //// Temp folders
            List<string> tempFolders = TempFolders.GetTempFolders();

            foreach (var folder in tempFolders)
            {
                GetFiles(folder, "*.*", context);
            }

            // File extensions
            List<string> fileFilters = FileExtensions.GetFileExtenshions();

            foreach (var filter in fileFilters)
            {
                GetFiles("C:\\", filter, context);
            }

            //// Cache folders
            //GetFiles("C:\\", "*cache*", context);

            context.Send(OnWorkCompleted, running);
        }

        private void GetFiles(string path, string pattern, SynchronizationContext context)
        {
            if (!running)
                return;

            try
            {
                if (chechFoldersCache)
                {
                    string lastFolderName = Path.GetFileName(Path.GetDirectoryName(path));
                    if (lastFolderName != null && lastFolderName.ToLower().Contains("cache"))
                    {
                        context.Send(OnDirFound, path);
                    }
                }
                else
                {
                    var list = Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly);
                    context.Send(OnFilesFound, list);
                }

                foreach (var directory in Directory.GetDirectories(path))
                    GetFiles(directory, pattern, context);
            }
            catch(Exception ex)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        context.Send(OnFileFound, path);
                    }
                }
                catch { }
            }
        }

        private void OnFileFound(object param)
        {
            if (OnProgressChanged != null)
            {
                OnProgressChanged((string) param);
            }
        }

        private void OnFilesFound(object param)
        {
            if (OnProgressChanged != null)
            {
                var arr = (string[])param;

                foreach (var file in arr)
                {
                    OnProgressChanged(file);
                }
            }
        }

        private void OnDirFound(object param)
        {
            if (OnProgressDirChanged != null)
            {
                var arr = (string)param;
                
                OnProgressDirChanged(arr);
            }
        }

        private void OnWorkCompleted(object cancelled)
        {
            if (OnFinished != null)
                OnFinished((bool)cancelled);
        }

        public event Action<string> OnProgressChanged;

        public event Action<string> OnProgressDirChanged;

        public event Action<bool> OnFinished;
    }
}
