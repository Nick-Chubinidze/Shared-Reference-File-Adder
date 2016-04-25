using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedReferenceFileAdder
{
    public interface IFile
    {
        void WriteAllText(string path,string contents);
    }
}
