using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedReferenceFileAdder
{
    public interface IUserFileHelper
    {
        string RelativePathCreatorFromOneSharedFolders(string sharedFolderPath, string csprojPath);

        string RelativePathCreatorFromSeveralSharedFolders(IEnumerable<string> sharedFolderPathes, string csprojPath);

        bool UserFileCreator(List<string> csprojPathes, string sharedFolderPath);

        IEnumerable<string> DirSearch(string sDir);
    }
}
