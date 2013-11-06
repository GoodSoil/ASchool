using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ASchoolSystem.BLL;
using ASchoolSystem.Entities;
using FakeItEasy;
using TestStack.BDDfy;
using TestStack.BDDfy.Scanners.StepScanners.Fluent;
using Xunit;
using Xunit.Extensions;
using ASchoolSystem.DAL;
using ASchoolSystem.Requirements.Helpers;

namespace ASchoolSystem.Requirements.AcceptanceTests.Scenarios.CourseManagerScenarios
{
    public class Adding_Proposed_Courses
    {
        #region Setup
        DbProviderFake FakeProvider { get; set; }

        public Adding_Proposed_Courses()
        {
            FakeProvider = DbProviderFake.Create().Instance();
        }
        #endregion
        #region Scenarios
        [Theory]
        [InlineData("Introductory Math", 1.5, 4)]
        public void ShouldAcceptWithMinimalCourseInformation(string name, double credits, int classHoursPerWeek)
        {
            CourseManager sut = null;
            int actualResponse = 0;
            int expected = 75;
            FakeProvider.WithRepo<Course>().ForInsert<Course>(expected);

            // Acceptance Test
            this.Given(_ => GivenACourseManager(out sut))
                .When(_ => WhenICreateAProposedCourse(sut, name, credits, classHoursPerWeek, out actualResponse))
                .Then(_ => Then_TheCourseIdIsReturned(expected, actualResponse))
                // TODO: Re-instate the following two parts of the story
                //.And(_ => Then_TheCourseNameStartsWith("PROPOSED-", actualResponse, sut))
                //.And(_ => Then_TheCourseStatusIs(CourseStatus.PROPOSED, actualResponse, sut))
                .BDDfy<ManageCourses_Proposed>("Add Course with Minimal Information");
        }

        [Fact(Skip= "This test is not developed yet")]
        public void ShouldRejectInsufficientCourseInformation()
        {
        }

        #endregion

        #region Secnario Steps
        public void Step()
        {
        }

        private void GivenACourseManager(out CourseManager sut)
        {
            // Arrange, Act
            sut = new CourseManager(FakeProvider.Provider, FakeProvider.ConnectionStringName);
            // Assert
            A.CallTo(() => FakeProvider.Provider.Instance(FakeProvider.ConnectionStringName)).MustHaveHappened();
        }

        private void WhenICreateAProposedCourse(CourseManager sut, string name, double credits, int classHoursPerWeek, out int  result)
        {
            // Arrange
            Course data = new Course() { CourseName = name, Credits = credits, ClassHourPerWeek = classHoursPerWeek };
            // Act
            result = sut.AddCourse(data);
            // Assert
            A.CallTo(() => FakeProvider.Context.GetRepository<Course>()).MustHaveHappened();
        }

        private void Then_TheCourseIdIsReturned(int expected, int actualResponse)
        {
            Assert.True(actualResponse > 0, "Expected to receive a Primary Key value greater than zero.");
            Assert.Equal(expected, actualResponse);
        }

        private void Then_TheCourseNameStartsWith(string text, int courseId, CourseManager sut)
        {
            Course info = sut.GetCourse(courseId);
            Assert.NotNull(info);
            Assert.True(info.CourseName.StartsWith(text));
        }

        private void Then_TheCourseStatusIs(CourseStatus status, int courseId, CourseManager sut)
        {
            Course info = sut.GetCourse(courseId);
            Assert.Equal(status.ToString(), info.Status);
        }
        #endregion
    }

    public class Changing_Proposed_Courses
    {
        #region Scenarios
        [Fact]
        public void Should_()
        {
            this.Given(_ => Step())
                .When(_ => Step())
                .Then(_ => Step())
                .BDDfy("Scenario_Description");
        }

        #endregion

        #region Secnario Steps
        public void Step()
        {
        }
        #endregion
    }

    public class Creating_Dependencies_For_Proposed_Courses
    {
        #region Scenarios
        [Fact]
        public void Should_()
        {
            this.Given(_ => Step())
                .When(_ => Step())
                .Then(_ => Step())
                .BDDfy("Scenario_Description");
        }

        #endregion

        #region Secnario Steps
        public void Step()
        {
        }
        #endregion
    }
}
