using AutoMapper;
using ControlePendencias.Application.Profiles;
using ControlePendencias.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControlePendencias.Application.Tests
{
    public class ApplicationBaseTest
    {
        protected IMapper Mapping { get; private set; }
        protected InMemoryDatabaseContext Context { get; private set; }

        [TestInitialize]
        public virtual void SetUp()
        {
            Context = new InMemoryDatabaseContext();

            Mapper.Initialize(config =>
            {
                config.ConstructServicesUsing(type => typeof(Mapper));

                config.AddProfile(new ResponsavelProfile());
                config.AddProfile(new PendenciaProfile());
            });

            Mapping = Mapper.Instance;
        }
    }
}
