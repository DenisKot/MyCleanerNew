using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyCleaner.Core.Configuration
{
    public struct DeleteFileWrapper
    {
        public List<string> filesList;

        public SynchronizationContext context;
    }
}
