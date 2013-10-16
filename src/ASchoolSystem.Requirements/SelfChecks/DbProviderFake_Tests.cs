using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASchoolSystem.Entities;
using ASchoolSystem.Requirements.Helpers;
using Xunit;
using Xunit.Extensions;
using ASchoolSystem.DAL;
using System.Collections;
using FakeItEasy;

namespace ASchoolSystem.Requirements.SelfChecks
{
    public class DbProviderFake_Tests
    {
        #region Instantiation Tests
        [Fact]
        public void Creates_IDataContextProvider_Fake()
        {
            DbProviderFake sut = DbProviderFake.Create().Instance();
            Assert.NotNull(sut.Provider);
        }

        [Fact]
        public void Creates_IDataContext_Fake()
        {
            DbProviderFake sut = DbProviderFake.Create().Instance();
            Assert.NotNull(sut.Context);
        }

        [Fact]
        public void Provider_Fake_Instance_Same_As_Context_Fake()
        {
            DbProviderFake sut = DbProviderFake.Create().Instance();
            Assert.Equal(sut.Provider.Instance(), sut.Context);
        }

        [Fact]
        public void Provider_Fake_Instance_From_ConnectionStringName_Same_As_Context_Fake()
        {
            DbProviderFake sut = DbProviderFake.Create().Instance();
            Assert.Equal(sut.Provider.Instance(sut.ConnectionStringName), sut.Context);
        }

        [Fact]
        public void Creates_A_Single_IRepository_Fake()
        {
            DbProviderFake sut = DbProviderFake.Create().WithRepo<Course>().Instance();
            IRepository<Course> actual = sut.GetRepository<Course>();
            Assert.NotNull(actual);
        }

        [Fact]
        public void Creates_Multiple_IRepository_Fake()
        {
            DbProviderFake sut = DbProviderFake.Create().WithRepo<Course>().WithRepo<CourseDependency>().Instance();
            IRepository<Course> actual = sut.GetRepository<Course>();
            Assert.NotNull(actual);
            IRepository<CourseDependency> actual2 = sut.GetRepository<CourseDependency>();
            Assert.NotNull(actual2);
        }
        #endregion

        #region Test Checks for Calls on Fakes
        [Fact]
        public void Ensure_Provider_Instance_Is_Called()
        {
            // Arrange
            DbProviderFake sut = DbProviderFake.Create().Instance();
            // Act
            sut.Provider.Instance();
            // Assert
            A.CallTo(() => sut.Provider.Instance()).MustHaveHappened();
        }

        [Fact]
        public void Ensure_Repo_Is_Called()
        {
            // Arrange
            DbProviderFake sut = DbProviderFake.Create().WithRepo<Course>().WithRepo<CourseDependency>().Instance();
            // Act
            sut.Context.GetRepository<Course>();
            // Assert
            A.CallTo(() => sut.Context.GetRepository<Course>()).MustHaveHappened();
        }

        [Fact]
        public void Ensure_Repo_Is_Not_Called()
        {
            // Arrange
            DbProviderFake sut = DbProviderFake.Create().WithRepo<Course>().WithRepo<CourseDependency>().Instance();
            // Act
            sut.Context.GetRepository<Course>();
            // Assert
            A.CallTo(() => sut.Context.GetRepository<CourseDependency>()).MustNotHaveHappened();
        }
        #endregion
    }
}
