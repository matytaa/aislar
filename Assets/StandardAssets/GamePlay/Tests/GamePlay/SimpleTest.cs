using NSubstitute;
using NUnit.Framework;

namespace StandardAssets.GamePlay.Tests.GamePlay
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
