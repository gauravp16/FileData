using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileData.Tests.Unit
{
    [TestClass]
    public class VersionQueryableTests
    {
        [DataTestMethod]
        [DataRow("-s")]
        [DataRow("--ajdkfjdk")]
        [DataRow("/fdkjfdk")]
        [DataRow("--hj")]
        public void Should_Return_False_If_Invalid_Pattern(string parameter)
        {
            var versionQueryable = new VersionQueryable(new MockFileAttributeService());

            Assert.IsFalse(versionQueryable.IsApplicable(parameter));
        }

        [DataTestMethod]
        [DataRow("-v")]
        [DataRow("--v")]
        [DataRow("/v")]
        [DataRow("--version")]
        public void Should_Return_True_If_Valid_Pattern(string parameter)
        {
            var versionQueryable = new VersionQueryable(new MockFileAttributeService());

            Assert.IsTrue(versionQueryable.IsApplicable(parameter));
        }

        [DataTestMethod]
        [DataRow("-v")]
        [DataRow("--v")]
        [DataRow("/v")]
        [DataRow("--version")]
        public void Should_Return_Size_If_Valid_Pattern(string parameter)
        {
            var versionQueryable = new VersionQueryable(new MockFileAttributeService());

            Assert.AreEqual("1.0", versionQueryable.Query("c:/test.txt", parameter));
        }
    }
}
