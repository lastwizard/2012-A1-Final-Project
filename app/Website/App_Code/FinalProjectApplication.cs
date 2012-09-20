namespace FinalProject.Web
{
    using System;
    using System.Web;
    using Castle.Windsor;
    using CommonServiceLocator.WindsorAdapter;
    using log4net.Config;
    using Microsoft.Practices.ServiceLocation;
    using SharpArch.Data.NHibernate;
    using SharpArch.Web.NHibernate;
    using FinalProject.Data.NHibernateMaps;
    using FinalProject.Web.CastleWindsor;

    //// Note: For instructions on enabling IIS6 or IIS7 classic mode,
    //// visit http://go.microsoft.com/?LinkId=9394801

    public class FinalProjectApplication : HttpApplication
    {
        #region Constants and Fields

        private WebSessionStorage webSessionStorage;

        #endregion

        #region Public Methods

        public override void Init()
        {
            base.Init();

            // The WebSessionStorage must be created during the Init() to tie in HttpApplication events
            this.webSessionStorage = new WebSessionStorage(this);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Due to issues on IIS7, the NHibernate initialization cannot reside in Init() but
        /// must only be called once.  Consequently, we invoke a thread-safe singleton class to
        /// ensure it's only initialized once.
        /// </summary>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            NHibernateInitializer.Instance().InitializeNHibernateOnce(this.InitializeNHibernateSession);
        }

        protected void Application_Start()
        {
            XmlConfigurator.Configure();
            this.InitializeServiceLocator();
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
        }

        /// <summary>
        /// Instantiate the container and add all Controllers that derive from
        /// WindsorController to the container.  Also associate the Controller
        /// with the WindsorContainer ControllerFactory.
        /// </summary>
        protected virtual void InitializeServiceLocator()
        {
            IWindsorContainer container = new WindsorContainer();
            ComponentRegistrar.AddComponentsTo(container);
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }

        /// <summary>
        /// If you need to communicate to multiple databases, you'd add a line to this method to
        /// initialize the other database as well.
        /// </summary>
        private void InitializeNHibernateSession()
        {
            NHibernateSession.Init(
                this.webSessionStorage, 
                new[] { this.Server.MapPath("~/bin/FinalProject.Data.dll") }, 
                new AutoPersistenceModelGenerator().Generate(), 
                this.Server.MapPath("~/config/NHibernate.config"));
        }

        #endregion
    }
}