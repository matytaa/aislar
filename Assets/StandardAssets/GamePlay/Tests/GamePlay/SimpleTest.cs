using NUnit.Framework;
using NSubstitute;

namespace Tests
{
    public class SimpleTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void SimpleTestSimplePasses()
        {
            var opponent = Substitute.For<SimpleTest>();
            // Use the Assert class to test conditions
        }
    }
}
