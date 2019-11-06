using System;
using System.Text;
using Xunit;
using Core;
using FluentAssertions;

namespace Core.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Should_Throw_Exception_When_ArgumentIsNull()
        {
            string s = null;

            Action act = () => s.ThrowIfNull(nameof(s));

            act.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void Should_Throw_Exception_When_ArgumentIsNull_Object()
        {
            object ob = null;

            Action act = () => ob.ThrowIfNull(nameof(ob));

            act.Should().Throw<ArgumentNullException>();

        }
    }
}
