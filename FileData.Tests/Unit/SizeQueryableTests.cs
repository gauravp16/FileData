using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileData.Tests.Unit
{
    [TestClass]
    public class SizeQueryableTests
    {
        [DataTestMethod]
        [DataRow("-v")]
        [DataRow("--ajdkfjdk")]
        [DataRow("/fdkjfdk")]
        [DataRow("--hj")]
        public void Should_Return_False_If_Invalid_Pattern(string parameter)
        {
            var sizeQueryable = new SizeQueryable(new MockFileAttributeService());

            Assert.IsFalse(sizeQueryable.IsApplicable(parameter));
        }

        [DataTestMethod]
        [DataRow("-s")]
        [DataRow("--s")]
        [DataRow("/s")]
        [DataRow("--size")]
        public void Should_Return_True_If_Valid_Pattern(string parameter)
        {
            var sizeQueryable = new SizeQueryable(new MockFileAttributeService());

            Assert.IsTrue(sizeQueryable.IsApplicable(parameter));
        }

        [DataTestMethod]
        [DataRow("-s")]
        [DataRow("--s")]
        [DataRow("/s")]
        [DataRow("--size")]
        public void Should_Return_Size_If_Valid_Pattern(string parameter)
        {
            var sizeQueryable = new SizeQueryable(new MockFileAttributeService());

            Assert.AreEqual("100", sizeQueryable.Query("c:/test.txt", parameter));
        }
    }
}
