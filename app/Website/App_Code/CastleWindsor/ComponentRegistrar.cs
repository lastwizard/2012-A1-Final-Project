using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FinalProject.Data.Repositories;
using SharpArch.Core.NHibernateValidator.CommonValidatorAdapter;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.PersistenceSupport.NHibernate;
using SharpArch.Data.NHibernate;
using SharpArch.Web.Castle;
using SharpArch.Core.CommonValidator;

namespace FinalProject.Web.CastleWindsor
{
    public class ComponentRegistrar
    {
        #region Public Methods

        public static void AddComponentsTo(IWindsorContainer container)
        {
            AddGenericRepositoriesTo(container);
            AddCustomRepositoriesTo(container);

            container.Register(
                    Component.For(typeof(IValidator))
                        .ImplementedBy(typeof(Validator))
                        .Named("validator"));
        }

        #endregion

        #region Methods

        private static void AddCustomRepositoriesTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes
                    .FromAssemblyNamed("FinalProject.Data")
                    .Pick()
                    .WithService.FirstNonGenericCoreInterface("FinalProject.Data"));
        }

        private static void AddGenericRepositoriesTo(IWindsorContainer container)
        {
            container.Register(
                Component.For(typeof(IEntityDuplicateChecker))
                    .ImplementedBy(typeof(EntityDuplicateChecker))
                    .Named("entityDuplicateChecker"));

            container.Register(
                Component.For(typeof(IRepository<>))
                    .ImplementedBy(typeof(Repository<>))
                    .Named("repositoryType"));

            container.Register(
                Component.For(typeof(INHibernateRepository<>))
                    .ImplementedBy(typeof(NHibernateRepository<>))
                    .Named("nhibernateRepositoryType"));

            container.Register(
                Component.For(typeof(IRepositoryWithTypedId<,>))
                    .ImplementedBy(typeof(RepositoryWithTypedId<,>))
                    .Named("repositoryWithTypedId"));

            container.Register(
                Component.For(typeof(INHibernateRepositoryWithTypedId<,>))
                    .ImplementedBy(typeof(NHibernateRepositoryWithTypedId<,>))
                    .Named("nhibernateRepositoryWithTypedId"));

            container.Register(
                    Component.For(typeof(ISessionFactoryKeyProvider))
                        .ImplementedBy(typeof(DefaultSessionFactoryKeyProvider))
                        .Named("sessionFactoryKeyProvider"));

            container.Register(
                     Component
                         .For(typeof(IRepository<>))
                         .ImplementedBy(typeof(BaseRepository<>))
                         .Named("baseRepository")
                         .LifeStyle.Is(LifestyleType.Transient)
                         );
        }

        #endregion
    }
}