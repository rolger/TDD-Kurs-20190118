using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace GarbageServiceExercise
{
    public class GarbageParserTest
    {
        [Fact]
        public void ShouldParseSingleWord()
        {
            List<String> result = Parse("VIENNA");
            result.Should().Contain("VIENNA");

            result = Parse("GRAZ");
            result.Should().Contain("GRAZ");
        }

        private List<string> Parse(string inputData)
        {
            return new GarbageParser().Parse(inputData);
        }
    }
}
