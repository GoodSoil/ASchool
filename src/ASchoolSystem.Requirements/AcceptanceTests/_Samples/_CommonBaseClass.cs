using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.BDDfy.Core;

namespace ASchoolSystem.Requirements.AcceptanceTests.Scenarios
{
    public class _CommonBaseClass
    {
        #region Internal class, for demonstration purposes only
        protected class StringChecker
        {
            public string FirstString { get; set; }
            public string SecondString { get; set; }

            public StringChecker(string firstString, string secondString)
            {
                FirstString = firstString;
                SecondString = secondString;
            }


            internal bool IsMatch()
            {
                return string.Equals(FirstString, SecondString);
            }
        }
        #endregion
    }
}
