using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedReferenceFileAdder
{
    class DirectoryWrapper : IDirectory
    {
        public bool Exists(string path)
        {
           return Directory.Exists(path);
        }
    }
}
