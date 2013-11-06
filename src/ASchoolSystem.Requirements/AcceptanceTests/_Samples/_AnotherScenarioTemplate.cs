using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.BDDfy;
using TestStack.BDDfy.Core;
using TestStack.BDDfy.Scanners.StepScanners.Fluent;
using Xunit;
using Xunit.Extensions;

namespace ASchoolSystem.Requirements.AcceptanceTests.Scenarios
{
    public class _AnotherScenarioTemplate : _CommonBaseClass
    {
        [Theory]
        [InlineData("p@ssword", "p@ssword")]
        [InlineData("12345", "12345")]
        [Trait("Sample", "99")]
        public void WriteParameterizedTests(string password, string confirmPassword)
        {
            StringChecker checker = null;
            this.Given(_ => GivenNonEmptyStrings(password, confirmPassword))
                .When(_ => WhenCheckingTheStrings(password, confirmPassword, out checker))
                .Then(_ => ThenTheStringsMatch(checker))
                .BDDfy<__AcceptanceTestTemplate>("Write a parameterized test to compare strings for equality");
        }

        private void GivenNonEmptyStrings(string firstString, string secondString)
        {
            Assert.False(string.IsNullOrEmpty(firstString));
            Assert.False(string.IsNullOrEmpty(secondString));
        }
        private void WhenCheckingTheStrings(string firstString, string secondString, out StringChecker checker)
        {
            checker = new StringChecker(firstString, secondString);
            Assert.NotNull(checker);
        }
        private void ThenTheStringsMatch(StringChecker checker)
        {
            Assert.True(checker.IsMatch());
        }
    }
}
