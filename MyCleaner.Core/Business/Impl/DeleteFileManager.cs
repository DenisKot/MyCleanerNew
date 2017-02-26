﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using MyCleaner.Core.Configuration;

namespace MyCleaner.Core.Business.Impl
{
    public class DeleteFileManager : Manager
    {
        public override void Work(object param)
        {
            DeleteFileWrapper wrapper = (DeleteFileWrapper) param;

            SynchronizationContext context = wrapper.context;
            List<string> files = wrapper.filesList;

            foreach (var file in files)
            {
                if (running)
                {
                    try
                    {
                        long size = new FileInfo(file).Length;

                        File.Delete(file);

                        FileDeletedWrapper wrapperResult = new FileDeletedWrapper();
                        wrapperResult.fileName = file;
                        wrapperResult.size = size;

                        context.Send(FileDeleted, wrapperResult);
                    }
                    catch (Exception)
                    {
                        context.Send(FileNotDeleted, file);
                    }
                }
            }

            context.Send(Finished, running);
        }

        private void FileDeleted(object param)
        {
            if (OnFileDeleted != null)
            {
                FileDeletedWrapper wrapper = (FileDeletedWrapper)param;
                OnFileDeleted(wrapper.fileName, wrapper.size);
            }
        }

        private void FileNotDeleted(object param)
        {
            if (OnFileNotDeleted != null)
            {
                OnFileNotDeleted((string)param);
            }
        }

        private void Finished(object successfull)
        {
            if (OnFinished != null)
                OnFinished((bool) successfull);
        }

        public event Action<string, long> OnFileDeleted;

        public event Action<string> OnFileNotDeleted;

        public event Action<bool> OnFinished;
    }
}
