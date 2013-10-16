using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASchoolSystem.Requirements.AcceptanceTests.Scenarios;
using TestStack.BDDfy;
using TestStack.BDDfy.Core;
using Xunit;
using Xunit.Extensions;

namespace ASchoolSystem.Requirements.AcceptanceTests
{
    [Story(AsA = "As a Curriculum Administrator",
               IWant = "I want to manage proposed courses",
               SoThat = "So that I can plan future curriculum",
               Title = "Manage Proposed Courses")]
    public class ManageCourses_Proposed
    {
    }
}
