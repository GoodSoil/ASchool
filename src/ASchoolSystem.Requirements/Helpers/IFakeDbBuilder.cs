using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASchoolSystem.DAL;
using FakeItEasy;

namespace ASchoolSystem.Requirements.Helpers
{
    /// <summary>
    /// This helper exists to facilitate a Fluent API in creating DbProviderFake Instances.
    /// </summary>
    interface IFakeDbBuilder
    {
        DbProviderFake Instance();
    }
    /// <summary>
    /// This helper exists to facilitate a Fluent API in creating DbProviderFake Instances with repository Insert/Update/Delete behaviour.
    /// </summary>
    interface IFakeRepoBuilder : IFakeDbBuilder
    {
        IFakeRepoBuilder WithRepo<T>() where T : class;
        IFakeRepoBuilder ForInsert<T>(object expected) where T : class;
        IFakeRepoBuilder ForUpdate<T>(int expected) where T : class;
        IFakeRepoBuilder ForDelete<T>(int expected) where T : class;
    }
}
