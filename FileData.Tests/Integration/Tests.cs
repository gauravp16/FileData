using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileData.Tests.Integration
{
    [TestClass]
    public class Tests
    {
        private App _app;

        [TestInitialize]
        public void Initialise()
        {
            _app = new App(new FileAttribueQueryable[] 
            {
                new SizeQueryable(new MockFileAttributeService(), new MockConfiguraionService()),
                new VersionQueryable(new MockFileAttributeService(), new MockConfiguraionService())
            });
        }
        
        [DataTestMethod]
        [DataRow("-s")]
        [DataRow("--s")]
        [DataRow("/s")]
        [DataRow("--size")]
        public void Should_Return_Size_For_Valid_Size_Pattern(string sizeInput)
        {
            var size = _app.Query("C:\test.txt", sizeInput);
            Assert.AreEqual("100", size);
        }

        [DataTestMethod]
        [DataRow("-v")]
        [DataRow("--v")]
        [DataRow("/v")]
        [DataRow("--version")]
        public void Should_Return_Version_For_Valid_Version_Pattern(string versionInput)
        {
            var version = _app.Query("C:\test.txt", versionInput);
            Assert.AreEqual("1.0", version);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_Error_WIth_Meaningful_Message_Invalid_File()
        {
            _app.Query(null, "-s");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_Error_With_Meaningful_Message_Invalid_Input()
        {
            _app.Query("c:\test.txt", "-ghhgh");
        }
    }
}
