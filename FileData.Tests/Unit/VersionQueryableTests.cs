using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileData.Tests.Unit
{
    [TestClass]
    public class VersionQueryableTests
    {
        private VersionQueryable _versionQueryable;

        [TestInitialize]
        public void Setup()
        {
            _versionQueryable = new VersionQueryable(new MockFileAttributeService(), new MockConfiguraionService());
        }

        [DataTestMethod]
        [DataRow("-s")]
        [DataRow("--ajdkfjdk")]
        [DataRow("/fdkjfdk")]
        [DataRow("--hj")]
        public void Should_Return_False_If_Invalid_Pattern(string parameter)
        {
            Assert.IsFalse(_versionQueryable.IsApplicable(parameter));
        }

        [DataTestMethod]
        [DataRow("-v")]
        [DataRow("--v")]
        [DataRow("/v")]
        [DataRow("--version")]
        public void Should_Return_True_If_Valid_Pattern(string parameter)
        {
            Assert.IsTrue(_versionQueryable.IsApplicable(parameter));
        }

        [DataTestMethod]
        [DataRow("-v")]
        [DataRow("--v")]
        [DataRow("/v")]
        [DataRow("--version")]
        public void Should_Return_Size_If_Valid_Pattern(string parameter)
        {
            Assert.AreEqual("1.0", _versionQueryable.Query("c:/test.txt", parameter));
        }
    }
}
