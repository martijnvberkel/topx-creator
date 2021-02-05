using System.Collections.Generic;
using System.Xml.Linq;
using Topx.Utility;

namespace Topx.UnitTests
{
    public enum Type { CreateDirectory, Save, FileCopy }
    public class Action
    {
        public Type Type;
        public string PathTarget;
        public string PathSource;
        public string Content;
    }
    public class MockIOUtilities : IIOUtilities
    {
        public List<Action> Actions = new List<Action>();

        public void DeleteDirectoryAndContent(string path)
        {
        }

        public void CreateDirectory(string targetDir)
        {
            Actions.Add(new Action { Type = Type.CreateDirectory, PathTarget = targetDir});
        }

        public void Save(XElement element, string path)
        {
            Actions.Add(new Action {Type = Type.Save, Content = element.ToString(), PathTarget = path});
        }

        public bool FileExists(string fullpath)
        {
            return true;
        }

        public void FileCopy(string source, string destination)
        {
            Actions.Add(new Action(){Type = Type.FileCopy, PathSource = source, PathTarget = destination});
        }

        public bool DirectoryExists(string directory)
        {
            return false;
        }

        public bool TestForValidCSV(string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}
