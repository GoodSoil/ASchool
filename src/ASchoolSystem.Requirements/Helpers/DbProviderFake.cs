using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASchoolSystem.DAL;
using ASchoolSystem.Entities;
using FakeItEasy;

namespace ASchoolSystem.Requirements.Helpers
{
    class DbProviderFake : IFakeRepoBuilder, IFakeDbBuilder
    {
        public string ConnectionStringName { get; private set; }
        public IDataContextProvider Provider { get; private set; }
        public IDataContext Context { get; private set; }
        private Dictionary<Type, Object> Repositories { get; set; }

        private DbProviderFake()
        {
            ConnectionStringName = "ASchoolTestData";
            Provider = A.Fake<IDataContextProvider>();
            Context = A.Fake<IDataContext>();
            Repositories = new Dictionary<Type, object>();
            
            // Set up connections between the fakes
            A.CallTo(() => Provider.Instance()).Returns<IDataContext>(Context);
            A.CallTo(() => Provider.Instance(ConnectionStringName)).Returns<IDataContext>(Context);
        }

        public IRepository<EntityType> GetRepository<EntityType>() where EntityType : class
        {
            return Repositories[typeof(EntityType)] as IRepository<EntityType>;
        }



        #region Builders
        public static IFakeRepoBuilder Create()
        {
            return new DbProviderFake();
        }

        public IFakeRepoBuilder WithRepo<TEntity>() where TEntity : class
        {
            var fakeRepo = A.Fake<IRepository<TEntity>>();
            Repositories.Add(typeof(TEntity), fakeRepo);
            A.CallTo(() => Context.GetRepository<TEntity>()).Returns<IRepository<TEntity>>(fakeRepo);
            return this;
        }

        public IFakeRepoBuilder ForInsert<EntityType>(object expected) where EntityType : class
        {
            var fakeRepo = GetRepository<EntityType>();
            A.CallTo(() => fakeRepo.Insert(A<EntityType>.Ignored)).Returns(expected);
            return this;
        }

        public IFakeRepoBuilder ForUpdate<EntityType>(int expected) where EntityType : class
        {
            var fakeRepo = GetRepository<EntityType>();
            A.CallTo(() => fakeRepo.Update(A<EntityType>.Ignored)).Returns(expected);
            return this;
        }

        public IFakeRepoBuilder ForDelete<EntityType>(int expected) where EntityType : class
        {
            var fakeRepo = GetRepository<EntityType>();
            A.CallTo(() => fakeRepo.Delete(A<EntityType>.Ignored)).Returns(expected);
            return this;
        }


        public DbProviderFake Instance()
        {
            return this;
        }
        #endregion
    }
}
