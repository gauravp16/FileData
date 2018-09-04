using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileData.Tests.Integration
{
    [TestClass]
    public class Tests
    {
        private App _app;
        private const string FILE_PATH = "c:/test.txt";

        [TestInitialize]
        public void Setup()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new TestModule());

            _app = builder.Build().Resolve<App>();
        }

        [DataTestMethod]
        [DataRow("-s")]
        [DataRow("--s")]
        [DataRow("/s")]
        [DataRow("--size")]
        public void Should_Return_Size_For_Valid_Size_Pattern(string sizeInput)
        {
            var size = _app.Query(FILE_PATH, sizeInput);
            Assert.AreEqual("100", size);
        }

        [DataTestMethod]
        [DataRow("-v")]
        [DataRow("--v")]
        [DataRow("/v")]
        [DataRow("--version")]
        public void Should_Return_Version_For_Valid_Version_Pattern(string versionInput)
        {
            var version = _app.Query(FILE_PATH, versionInput);
            Assert.AreEqual("1.0", version);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_Error_WIth_Meaningful_Message_Invalid_File()
        {
            _app.Query(null, "-s");
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("ghhgh")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_Error_With_Meaningful_Message_Invalid_Input(string input)
        {
            _app.Query(FILE_PATH, input);
        }

        

    }
}
