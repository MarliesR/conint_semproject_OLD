using System;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int one = 1;
            int two = 2;

            int sum = one + two;

            Assert.Equal(3, sum);
        }
    }
}
