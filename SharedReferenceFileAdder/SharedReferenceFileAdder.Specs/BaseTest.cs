using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharedReferenceFileAdder;

namespace SharedReferenceFileAdder.Specs
{
    [TestClass]
    public class BaseTest
    {
        protected Mock<IDirectory> Directory;
        protected Mock<IFile> File;

        protected UserFileHelper UFH;

        protected List<string> CsprojList;


        [TestInitialize]
        public void Init()
        {
            CsprojList = new List<string> {
                "C:\\Users\\Nick\\Desktop\\a\\New folder\\New folder\\Abc\\Abc\\Abc.csproj",
                "C:\\Users\\Nick\\Desktop\\a\\New folder\\New folder\\Abc\\SalesDataAnalyse.Specs\\SalesDataAnalyse.Specs.csproj",
                "C:\\Users\\Nick\\Desktop\\a\\New folder\\New folder\\Abc\\SalesDataAnalyse.Specs\\WindowsFormsApplication1\\WindowsFormsApplication1.csproj",
                "C:\\Users\\Nick\\Desktop\\a\\New folder\\New folder\\Abc\\SalesDataAnalyse.Specs\\WindowsFormsApplication1\\WindowsFormsApplication1\\WindowsFormsApplication1.csproj",
                "C:\\Users\\Nick\\Desktop\\a\\New folder\\New folder\\Abc\\WindowsFormsApplication1\\WindowsFormsApplication1.csproj"
            };

            File = new Mock<IFile>();
            File.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            Directory = new Mock<IDirectory>();

            Directory.Setup(x => x.Exists("C:\\Shared\\sha")).Returns(true);
            Directory.Setup(x => x.Exists("C:\\Users\\Shared")).Returns(true);

            UFH = new UserFileHelper(Directory.Object, File.Object);
        }
    }
}
