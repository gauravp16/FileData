using FileData.Queryables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileData.Tests.Unit
{
    [TestClass]
    public class SizeQueryableTests
    {
        private SizeQueryable _sizeQueryable;

        [TestInitialize]
        public void Setup()
        {
            _sizeQueryable = new SizeQueryable(new MockFileAttributeService(), new MockConfiguraionService());
        }

        [DataTestMethod]
        [DataRow("-v")]
        [DataRow("--ajdkfjdk")]
        [DataRow("/fdkjfdk")]
        [DataRow("--hj")]
        public void Should_Return_False_If_Invalid_Pattern(string parameter)
        {
            Assert.IsFalse(_sizeQueryable.IsApplicable(parameter));
        }

        [DataTestMethod]
        [DataRow("-s")]
        [DataRow("--s")]
        [DataRow("/s")]
        [DataRow("--size")]
        public void Should_Return_True_If_Valid_Pattern(string parameter)
        {
            Assert.IsTrue(_sizeQueryable.IsApplicable(parameter));
        }

        [DataTestMethod]
        [DataRow("-s")]
        [DataRow("--s")]
        [DataRow("/s")]
        [DataRow("--size")]
        public void Should_Return_Size_If_Valid_Pattern(string parameter)
        {
            Assert.AreEqual("100", _sizeQueryable.Query("c:/test.txt", parameter));
        }
    }
}
