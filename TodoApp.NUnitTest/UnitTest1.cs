using Moq;
using NUnit.Framework;
using TodoApp.Core.Model;
using TodoApp.Core.Repositories;

namespace TodoApp.NUnitTest
{
    public class Tests
    {
        private readonly Mock<IWorkRepository> _mockRepo;

        public Tests(Mock<IWorkRepository> mockRepo)
        {
            _mockRepo = mockRepo;
        }


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            
        }
    }
}