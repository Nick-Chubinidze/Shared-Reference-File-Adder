using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SharedReferenceFileAdder
{
    public class UserFileHelper : IUserFileHelper
    {
        private readonly IDirectory _dir;
        private readonly IFile _file;

        public UserFileHelper(IDirectory dir, IFile file)
        {
            _dir = dir;
            _file = file;
        }

        IEnumerable<string> IUserFileHelper.DirSearch(string sDir)
        {
            var files = new List<string>();

            try
            {
                files.AddRange(Directory.GetFiles(sDir));

                foreach (var d in Directory.GetDirectories(sDir))
                    files.AddRange(((IUserFileHelper)this).DirSearch(d));
            }
            catch (Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }

        public string RelativePathCreatorFromSeveralSharedFolders(IEnumerable<string> sharedFolderPathes, string csprojPath)
        {
            var relPath = sharedFolderPathes
                .Aggregate((string)null, (current, s) => current + AbsoluteToRelativePathConverter(s, csprojPath) + ';');

            return relPath.Remove(relPath.Length - 1);
        }

        public string RelativePathCreatorFromOneSharedFolders(string sharedFolderPath, string csprojPath)
        {
            var relPath = AbsoluteToRelativePathConverter(sharedFolderPath, csprojPath);

            return relPath;
        }

        private static string AbsoluteToRelativePathConverter(string sharedFolderPath, string projectPath)
        {
            var fullPath = new Uri(sharedFolderPath, UriKind.Absolute);
            var relRoot = new Uri(projectPath, UriKind.Absolute);

            return relRoot.MakeRelativeUri(fullPath).ToString().Replace('/', '\\');
        }

        public bool UserFileCreator(List<string> csprojPathes, string sharedFolderPath)
        {
            if (sharedFolderPath.Contains(';'))
            {
                var pathes = sharedFolderPath.Split(';').Where(t => t.Length > 1).ToArray();

                for (var i = 0; i < pathes.Length; i++)
                {
                    for (var j = i + 1; j < pathes.Length; j++)
                    {
                        if (pathes[i] == pathes[j])
                            return false;
                    }
                }

                if (pathes.Any(p => !_dir.Exists(p)))
                    return false;

                foreach (var item in csprojPathes)
                {
                    var relativePath = RelativePathCreatorFromSeveralSharedFolders(pathes, item);

                    UserFileTextWriter(item, relativePath);
                }

                return true;
            }

            if (!_dir.Exists(sharedFolderPath))
                return false;

            foreach (var item in csprojPathes)
            {
                var relativePath = RelativePathCreatorFromOneSharedFolders(sharedFolderPath, item);

                UserFileTextWriter(item, relativePath);
            }

            return true;
        }

        private void UserFileTextWriter(string item, string relativePath)
        {
            var path = item + ".user";

            //if (File.Exists(path))
            //    return;

            var fileBody = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Project ToolsVersion=""14.0"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">
  <PropertyGroup>
    <ReferencePath>{relativePath}</ReferencePath>
  </PropertyGroup>
</Project>";

            _file.WriteAllText(path, fileBody);
        }
    }
}
