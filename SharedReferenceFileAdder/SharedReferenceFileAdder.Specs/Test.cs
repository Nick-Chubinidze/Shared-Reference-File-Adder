using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace SharedReferenceFileAdder.Specs
{
    [TestClass]
    public class When_User_Types_unexisting_SharedFolder : BaseTest
    {
        [TestMethod]
        public void UserFiles_Should_Not_Be_Created()
        {  
           UFH.UserFileCreator(CsprojList, "C:\\Users\\Sharedery").ShouldBeFalse(); 
        } 
    }

    [TestClass]
    public class When_One_Of_The_Typed_SharedFolders_Does_Not_Exist : BaseTest
    {
        [TestMethod]
        public void UserFiles_Should_Not_Be_Created()
        { 
            UFH.UserFileCreator(CsprojList, "C:\\Shared\\sha;C:\\Users\\Sharedsss").ShouldBeFalse();
        }
    }

    [TestClass]
    public class When_One_Of_The_Typed_SharedFolders_Matches_With_Another : BaseTest
    {
        [TestMethod]
        public void UserFiles_Should_Not_Be_Created()
        {
            UFH.UserFileCreator(CsprojList, "C:\\Shared\\sha;C:\\Users\\Shared;C:\\Shared\\sha").ShouldBeFalse();
        }
    }

    [TestClass]
    public class When_Typed_SharedFolder_Exist : BaseTest
    {
        [TestMethod]
        public void UserFiles_Should_Not_Be_Created()
        {
            UFH.UserFileCreator(CsprojList, "C:\\Users\\Shared").ShouldBeTrue();
        }
    }

    [TestClass]
    public class When_Typed_SharedFolders_Exist : BaseTest
    {
        [TestMethod]
        public void UserFiles_Should_Not_Be_Created()
        {
            UFH.UserFileCreator(CsprojList, "C:\\Shared\\sha;C:\\Users\\Shared").ShouldBeTrue();
        }
    }
}
