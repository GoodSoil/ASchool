using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.BDDfy;
using TestStack.BDDfy.Core;
using TestStack.BDDfy.Scanners.StepScanners.Fluent;
using Xunit;

namespace ASchoolSystem.Requirements.AcceptanceTests.Scenarios
{
    public class _ABasicScenarioTemplate : _CommonBaseClass
    {
        [Fact]
        [Trait("Sample", "99")]
        public void WriteSimpleTests()
        {
            StringChecker checker = null;
            string expectedFirst = "First", expectedSecond = "Second";
            this.When(_ => WhenCreatingAStringCheckerWithDifferentStrings(expectedFirst, expectedSecond, out checker), false)
                .Then(_ => ThenTheCheckerStoresTheStringValues(expectedFirst, expectedSecond, checker), false)
                .BDDfy<__AcceptanceTestTemplate>("Write a simple test to check constructors and public properties of StringChecker");
            
        }
        private void WhenCreatingAStringCheckerWithDifferentStrings(string first, string second, out StringChecker checker)
        {
            checker = new StringChecker(first, second);
        }
        private void ThenTheCheckerStoresTheStringValues(string first, string second, StringChecker checker)
        {
            Assert.Equal(first, checker.FirstString);
            Assert.Equal(second, checker.SecondString);
        }
    }
}