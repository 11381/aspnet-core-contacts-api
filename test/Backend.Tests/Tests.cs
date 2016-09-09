using System;
using Xunit;

namespace Backend.UnitTests
{
    public class Tests
    {
        readonly TestCode code;
        public Tests(){
            code = new TestCode();
        }

        [Fact]
        public void TestImplementationShouldBeTrue() 
        {
            var value = code.TestImplementation();
            Assert.True(value);
        }
    }
}