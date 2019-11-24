using AutoMapper;
using ControlePendencias.Application;
using ControlePendencias.Application.Interfaces;
using ControlePendencias.Application.Profiles;
using ControlePendencias.Application.ViewModels;
using ControlePendencias.CrossCutting;
using InMemory = ControlePendencias.Data;
using Firebird = ControlePendencias.Data.Firebird;
using ControlePendencias.Domain;
using ControlePendencias.Domain.Interfaces;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common.WebHost;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ControlePendencias.Web
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            base.OnApplicationStarted();
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new AutoMapperModule());
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private void RegisterServices(IKernel kernel)
        {
            //Singleton pois os dados estão na memória.
            //kernel.Bind<InMemory.InMemoryDatabaseContext>().ToSelf().InSingletonScope();

            kernel.Bind<Firebird.FirebirdContext>().ToSelf().InTransientScope();
            kernel.Bind<IEMailSender>().To<GmailEmailSender>();
            kernel.Bind<IPendenciaRepository>().To<Firebird.PendenciaRepository>();
            kernel.Bind<IResponsavelRepository>().To<Firebird.ResponsavelRepository>();
            kernel.Bind<IApplicationBase<PendenciaViewModel>>().To<ApplicationBase<PendenciaViewModel, Pendencia>>();
            kernel.Bind<IApplicationBase<ResponsavelViewModel>>().To<ApplicationBase<ResponsavelViewModel, Responsavel>>();
            kernel.Bind<IPendenciaApplication>().To<PendenciaApplication>();
            kernel.Bind<IResponsavelApplication>().To<ResponsavelApplication>();
        }

    }






    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
        }

        private IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.ConstructServicesUsing(type => context.Kernel.Get(type));

                config.AddProfile(new ResponsavelProfile());
                config.AddProfile(new PendenciaProfile());
            });

            Mapper.AssertConfigurationIsValid(); // optional
            return Mapper.Instance;
        }
    }
}
